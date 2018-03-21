using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataLoaderTest.Core
{
    public class PropertyBag : IEnumerable<PropertyBag>
    {
        public static PropertyBag FromFile(string filename)
        {
            var lines = File.ReadAllLines(filename);
            //pre-proccess the text in file

            
            IEnumerable<string> includeText = PropertyBagParser.ParseInclude(Path.GetDirectoryName(filename), lines);
            IEnumerable<string> noBlankText = PropertyBagParser.StripEmptyLines(includeText);
            IEnumerable<string> noCommentText= PropertyBagParser.StripComment(noBlankText);

            ShowLines(noCommentText);
            IndentationTree tree = IndentationTree.Parse(noCommentText);

            PropertyBagParser.Parse(tree);
            
            return new PropertyBag();
        }

        #region Pre-handle
        private static void ShowLines(IEnumerable<string> lines)
        {
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
        #endregion


        public IEnumerator<PropertyBag> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public static class PropertyBagParser
    {
        public static IEnumerable<string> StripEmptyLines(IEnumerable<string> lines)
        {
            if (lines == null) throw new ArgumentNullException("lines");

            return lines.Where(line => line.Trim().Length > 0);
        }

        public static IEnumerable<string> StripComment(IEnumerable<string> lines)
        {
            if (lines == null) throw new ArgumentNullException("lines");

            return lines.Select(line => sCommentRegex.Match(line).Groups["content"].Value);
        }

        public static IEnumerable<string> ParseInclude(string basePath,IEnumerable<string> lines)
        {
            if (basePath == null) throw new ArgumentNullException("basePath");
            if (lines == null) throw new ArgumentNullException("lines");

            foreach (string line in lines)
            {
                Match match = sIncludeRegex.Match(line);

                if (match.Success)
                {
                    string path = match.Groups["path"].Value;
                    path = Path.Combine(basePath, path);

                    // if is a dir, add all files in this dir
                    if (Directory.Exists(path))
                    {
                        foreach (string filePath in Directory.GetFiles(path))
                        {
                            string[] includedLines = File.ReadAllLines(filePath);
                            foreach (var includedLine in ParseInclude(Path.GetDirectoryName(path),includedLines) )
                            {
                                yield return includedLine;
                            }
                        }

                    }
                    //if it's a file
                    else if (File.Exists(path))
                    {
                        string[] includedLines = File.ReadAllLines(path);
                        foreach (string includedLine in ParseInclude(Path.GetDirectoryName(path), includedLines))
                        {
                            yield return includedLine;
                        }
                    }
                    else
                    {
                        Console.WriteLine("could not find the include in " + path);
                        throw new DirectoryNotFoundException(path);
                    }
                }
                else
                    yield return line;
            }
        }

        public static PropertyBag Parse(IndentationTree tree)
        {

        }

        #region Regular expresions
        private static Regex sCommentRegex = new Regex(
            @"^(?<content>.*?)      # everything before the comment
               (?<comment>//.*)?$   # the comment",
            RegexOptions.Compiled | RegexOptions.ExplicitCapture | RegexOptions.IgnorePatternWhitespace);

        private static Regex sLineRegex = new Regex(
            @"
            ^(?<abstract>::)?             # may be abstract
             (?<name>..*?)                # name
             ((?<equals>=)(?<value>..*?)? # '= value' (value may be omitted)
             |(::(?<inherits>.*?))*       # or base props
             |                            # or nothing
             )$
            ",
            RegexOptions.Compiled | RegexOptions.ExplicitCapture | RegexOptions.IgnorePatternWhitespace);

        private static Regex sIncludeRegex = new Regex(
            @"
            ^\s*                # allow space before the include
             \#include          # the include command
             \s*                # allow space after the include
             ""(?<path>.*)""    # the include path
             $
            ",
            RegexOptions.Compiled | RegexOptions.ExplicitCapture | RegexOptions.IgnorePatternWhitespace);
        #endregion
    }

    public class IndentationTree
    {

        public static IndentationTree Parse(IEnumerable<string> lines)
        {
            Stack<IndentationTree> stack = new Stack<IndentationTree>();
            IndentationTree root = new IndentationTree(-1, string.Empty);
            stack.Push(root);
            foreach (string line in lines)
            {
                Match match = sIndentRegex.Match(line);
                if (match.Success)
                {
                    int cuurentIndent = Convert.ToInt32(match.Groups["indent"].Value);
                    string currentText = match.Groups["text"].Value;

                    IndentationTree node = new IndentationTree(cuurentIndent, currentText);
                    //it is the sub-level
                    if (cuurentIndent > stack.Peek().Indent)
                    {
                        stack.Peek().mChildren.Add(node);
                        stack.Push(node);
                    }
                    else if (cuurentIndent <= stack.Peek().Indent)
                    {
                        while (cuurentIndent < stack.Peek().Indent)
                        {
                            stack.Pop();
                        }
                        stack.Peek().mChildren.Add(node);
                        stack.Push(node);
                    }

                }
                else
                {
                    throw new Exception("cannot match indent line");
                }
            }
            root.NormalizeIndentation(-1);
            return root;
        }

        private void NormalizeIndentation(int currentIndent)
        {
            mIndent = currentIndent;
            foreach (IndentationTree tree in mChildren)
            {
                NormalizeIndentation(tree.Indent+1);
            }
        }

        private static Regex sIndentRegex = new Regex(
            @"^(?<indent>\s*) # leading whitespace
               (?<text>.*)$   # everything else",
            RegexOptions.Compiled | RegexOptions.ExplicitCapture | RegexOptions.IgnorePatternWhitespace);


        #region Constructor
        public IndentationTree(int indent,string text)
        {
            mIndent = indent;
            mText = text;
            mChildren = new List<IndentationTree>();
        }
        #endregion

        #region Fields

        private int mIndent;
        private string mText;
        private List<IndentationTree> mChildren;

        public int Indent { get { return mIndent; } }
        public string Text { get { return mText; } }
        
        public ReadOnlyCollection<IndentationTree> Children
        {
            get { return new ReadOnlyCollection<IndentationTree>(mChildren); }
        }
        #endregion
    }
}
