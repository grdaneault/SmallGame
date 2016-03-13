﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SmallGame
{

    public class RenderEventArgs : EventArgs
    {
        public SpriteBatch SpriteBatch { get; set; }
        public PrimitiveBatch PrimitiveBatch { get; set; }
        public GraphicsDevice Graphics { get { return SpriteBatch.GraphicsDevice; } }

        public RenderEventArgs(SpriteBatch spriteBatch, PrimitiveBatch primitiveBatch)
        {
            SpriteBatch = spriteBatch;
            PrimitiveBatch = primitiveBatch;
        }
    }

    public class RenderService : CoreGameService
    {

        public SpriteBatch SpriteBatch { get; set; }
        public PrimitiveBatch PrimitiveBatch { get; set; }
        public GraphicsDevice Graphics { get { return SpriteBatch.GraphicsDevice; } }
        public Color ClearColor { get; set; }

        public EventHandler<RenderEventArgs> OnRender { get; set; }
        
        public RenderService()
        {
            ClearColor = Color.Black;
            OnRender = (sender, args) => { };
        }

        public void Configure(SpriteBatch spriteBatch, PrimitiveBatch primitveBatch)
        {
            SpriteBatch = spriteBatch;
            PrimitiveBatch = primitveBatch;
        }

        public void Empty()
        {
            OnRender = (sender, args) => { };
        }

        public void Render()
        {
            Graphics.Clear(ClearColor);

            SpriteBatch.Begin();
            OnRender.Invoke(this, new RenderEventArgs(SpriteBatch, PrimitiveBatch));
            SpriteBatch.End();

        }

    }
}
