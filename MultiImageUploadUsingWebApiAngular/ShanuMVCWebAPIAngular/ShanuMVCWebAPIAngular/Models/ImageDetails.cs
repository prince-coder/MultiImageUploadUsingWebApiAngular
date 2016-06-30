using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShanuMVCWebAPIAngular.Models
{
    public class ImageDetails
    {
        
        
            [Key]
            public int ImageID { get; set; }
            public string Image_Path { get; set; }
            public string Description { get; set; }
        }
    }
