﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModellenBureau.Models
{
    public class AppFile
    {
        public int Id { get; set; }
        public byte[] Content { get; set; }
    }
    public class BufferedSingleFileUploadDbModel : PageModel
    {
    [BindProperty]
        public BufferedSingleFileUploadDb FileUpload { get; set; }
}

    public class BufferedSingleFileUploadDb
    {
        [Required]
        [Display(Name = "File")]
        public IFormFile FormFile { get; set; }
    }
}
