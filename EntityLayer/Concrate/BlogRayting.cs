using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrate
{
    public class BlogRayting
    {
        public int BlogRaytingID { get; set; }
        public int BlogID { get; set; }
        public int BlogTotalScore { get; set; }
        public int BlogRaytingCount { get; set; }
    }
    //Sql'de tetikleyici oluşturup işlem yaptıracağız =>

    //1.Aşama=>BlogID'yi alacak tabloya ekleyecek
    //Create Trigger AddBlogInRaytingTable
    //On Blogs
    //After Insert
    //As
    //Declare @ID int
    //Select @ID=BlogID from inserted
    //Insert Into BlogRaytings(BlogID, BlogTotalScore, BlogRaytingCount)
    //Values(@ID,0,0)

    //2.Aşama=> BlogRaytings tablosuna BlogTotalScore eklenecek
    //Create Trigger AddScoreInComment
    //On Comments
    //After Insert
    //As
    //Declare @ID int
    //Declare @Score int
    //Declare @RaytingCount int
    //Select @ID=BlogID,@Score=BlogScore from inserted
    //Update BlogRaytings Set BlogTotalScore=BlogTotalScore+@Score,BlogRaytingCount+=1
    //Where BlogID = @ID
}
