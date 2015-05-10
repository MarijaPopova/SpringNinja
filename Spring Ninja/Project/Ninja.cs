using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Project
{
   public class Ninja : SceneObjects
   {    
       
       // Image

       private Image ninja; 
       private Image imageSpring = Properties.Resources.spring as Image;
       private Image imageNinja = Properties.Resources.ninja as Image;


       // Bool

       private bool isJumpingImage;
       public bool Stop_Horizontal_Movement { get; set; } 
       public bool First_Time { get; set; }



       // Int

       private int height;
       public int SpringHeight { get; set; }
       public int dy { get; set; }
       public int dx { get; set; }
       public int nextPlatform { get; set; }
      

       public Ninja(int X, int Y)  : base(X, Y)
       {  
           
           
           // Image

           ninja = imageSpring;

           // Bool

           isJumpingImage = false;
           Stop_Horizontal_Movement = false;
           First_Time = true;



           // Int

           SpringHeight = 13;
           height = 50;
           dy=0;
           dx=5;
           nextPlatform = 1;
           
       }

       // Ovde se azurira (precrtuva ) Ninjata. Ovoj metod se povikuva samo vo Stage.paint---->Handlerot  vo glavnata forma 
       public override void Draw(Graphics g)
       {    
           if (!isJumpingImage)
           {
               int offset = height - SpringHeight;
               g.DrawImage(ninja, this.X, this.Y + offset, this.width, this.SpringHeight );
               g.DrawImage(imageNinja, this.X, this.Y - this.height + offset, this.width, this.height);

           }
           else
           {
               g.DrawImage(ninja, this.X, this.Y, this.width, this.height );
           }
            
       }

       // Ja precrtuva slikata vo zavisnost od toa dali skoka Ninjata ili pak e smesten na nekoja platforma
       public void ChangePicture()
       {
           if (!isJumpingImage)
           {
               ninja = imageNinja; 
               
               isJumpingImage = true;
                
           }
           else
           {
               ninja = imageSpring; 
               isJumpingImage = false;
            

           }
       }



       //Rakuvanje so Animacijata za vrakjanje na Springot(Federot) otkako Ninjata stapnal na nekoja platforma .
       public void AnimateReflection(int reflection)
       {
           if (reflection>31) return;
           SpringHeight--;
           
       }

       // Animacija za skokot na Ninjata
       public void Jump(GamePanel stage ,SpringNinja form)
       { 
             dy += 1; // Namaluvanje na zabrzuvanjeto (the velocity).
              
             this.Y+=dy; // Zabrzuvanje po y-oskata.

             if (!Stop_Horizontal_Movement)
             { 
                     this.X += dx;  // Logikata e treba da se  dvizi ninjata po X oskata ako i samo ako ne se udril od strana so nekoja platforma. Zatoa ovoj test .
                     form.CanavasSlider -= dx; 
               
             }

             if (First_Time)
             {
                    this.ChangePicture();
                    First_Time = false;

             }
              
       }
        
      



    }
}
