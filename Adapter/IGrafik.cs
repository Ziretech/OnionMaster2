using System.Drawing;

namespace Adapter
{
    public interface IGrafik
    {
        void AktiveraTextur(int textureId, int width, int height);
        void InitieraGrafik();
        void KopieraTexturrektangelTillRityta(int texturX, int texturY, int ritytaX, int ritytaY, int bredd, int höjd);
        int LaddaTextur(Bitmap bitmap);
        void TömRityta();
        void ÄndraStorlek(int width, int height);        
    }
}