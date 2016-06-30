using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShanuMVCWebAPIAngular.Models
{
    public class ImageContext: DbContext
    {
        public  DbSet<ImageDetails> ImageDetails { get; set; }
    }
}