using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Models;

namespace TodoApp.Services
{
    class FileIOServices
    {

        private readonly string PATH;

        public FileIOServices(string path)
        {
            PATH = path;
        }

        public void SaveData(object todoDataList)
        {
            using(StreamWriter writer = File.CreateText(PATH))
            {
                string outpat = JsonConvert.SerializeObject(todoDataList);
                    writer.Write(outpat);
            }

        }
    }
}
