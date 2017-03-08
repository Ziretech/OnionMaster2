using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using OpenTK;
using System.Drawing.Imaging;
using PixelFormat = OpenTK.Graphics.OpenGL.PixelFormat;
using Regel;

namespace Adapter
{
    public class OpenGLGrafik : IGrafik
    {
        public void InitieraGrafik()
        {
            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
        }

        public int LaddaTextur(Bitmap bitmap)
        {
            int textureId = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, textureId);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
            var data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height,
                0, PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            bitmap.UnlockBits(data);
            return textureId;
        }

        public void AktiveraTextur(int textureId, int width, int height)
        {
            GL.BindTexture(TextureTarget.Texture2D, textureId);
            GL.MatrixMode(MatrixMode.Texture);
            GL.LoadIdentity();
            GL.Scale(1.0 / width, 1.0 / height, 1.0);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        public void TömRityta()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
        }

        public void ÄndraStorlek(int width, int height)
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0.0, width / 2.0, 0.0, height / 2.0, 0.0, 4.0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.Viewport(0, 0, width, height);
        }

        public void KopieraTexturrektangelTillRityta(int texturX, int texturY, int ritytaX, int ritytaY, int bredd, int höjd)
        {
            var t1 = new Vector2(texturX, texturY);
            var t2 = new Vector2(texturX + bredd, texturY + höjd);
            var s1 = new Vector2(ritytaX, ritytaY);
            var s2 = new Vector2(ritytaX + bredd, ritytaY + höjd);

            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(t1.X, t2.Y);
            GL.Vertex2(s1);

            GL.TexCoord2(t2);
            GL.Vertex2(s2.X, s1.Y);

            GL.TexCoord2(t2.X, t1.Y);
            GL.Vertex2(s2);

            GL.TexCoord2(t1);
            GL.Vertex2(s1.X, s2.Y);
            GL.End();
        }
    }
}
