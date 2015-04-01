using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVTester.Models
{
    public class ImageData
    {
        /// <summary>
        /// Database generated ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Byte array containing image
        /// </summary>
        public byte[] Image { get; set; }

        /// <summary>
        /// Type of picture (used for classification)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// URL link to picture
        /// </summary>
        public string Link { get; set; }
    }
}
