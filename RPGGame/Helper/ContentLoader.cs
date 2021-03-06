﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using RPGGame.Scenes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.Helper
{
    public class ContentLoader : IContentLoader
    {
        private const string TextureNotFoundName = "NotFoundTexture";
        private const string FontNotFoundName = "NotFoundFont";
        private readonly ContentManager contentManager;
        private readonly Dictionary<string, Texture2D> textureByName;
        private readonly Dictionary<string, SpriteFont> fontByName;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public ContentLoader(ContentManager contentManager)
        {
            this.contentManager = contentManager;
            textureByName = new Dictionary<string, Texture2D>();
            fontByName = new Dictionary<string, SpriteFont>();
        }

        public Texture2D LoadTexture(string textureName)
        {
            if (!textureByName.ContainsKey(textureName))
            {
                try
                {
                    var texture = contentManager.Load<Texture2D>(Path.Combine("Textures", textureName));
                    textureByName.Add(textureName, texture);
                    return texture;
                }
                catch (Exception) when (textureName != TextureNotFoundName)
                {
                    return LoadTexture(TextureNotFoundName);
                }
            }
            return textureByName[textureName];
        }

        public SpriteFont LoadFont(string fontName)
        {
            if (!fontByName.ContainsKey(fontName))
            {
                try
                {
                    var font = contentManager.Load<SpriteFont>(Path.Combine("Fonts", fontName));
                    fontByName.Add(fontName, font);
                    return font;
                }
                catch (Exception) when (fontName != FontNotFoundName)
                {
                    return LoadFont(FontNotFoundName);
                }
            }
            return fontByName[fontName];
        }

        public MapData LoadMap(string id)
        {
            MapData mapData = new MapData();
            
            //contentManager.Load<StringReader>
            return mapData;
        }

        public Texture2D LoadImage(string fileName)
        {
            var texture = contentManager.Load<Texture2D>(Path.Combine("Textures", fileName));
            return texture;
        }
    }
}
