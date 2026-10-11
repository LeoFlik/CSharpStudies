using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookieRecipeBook.FileAcess;

namespace CookieRecipeBook.FileAcess;

    public class FileMetaData
    {
        public string? Name { get;}
        public FileFormat Format { get;}

        public FileMetaData(string name,FileFormat format)
        {
            Name = name;
            Format = format;
        }

        public string Path()=> $"{Name}.{Format.AsFileExtension()}";
        
    }
