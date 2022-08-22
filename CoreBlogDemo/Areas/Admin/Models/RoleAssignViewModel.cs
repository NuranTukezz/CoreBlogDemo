namespace CoreBlogDemo.Areas.Admin.Models
{
    public class RoleAssignViewModel
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        
        public bool Exist { get; set; }//=>BU ROL BU KULLANICIDA VAR MI
    }
}
