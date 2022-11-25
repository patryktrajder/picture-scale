using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;

namespace Resizer {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Siema ziomeczku");

            if (args.Length == 0) {
                Console.WriteLine("Podaj folder ziomeczku\nresizer.exe <path> (-h height | -w width)");
                return;
            }

            string dir = args[0];
            int? height = null;
            int? width = null;

            if (args.Length >= 2) {
                if (args[1] == "-h") {
                    if (args.Length >= 3) {
                        if (int.TryParse(args[2], out int h)) {
                            height = h;
                        } else {
                            Console.WriteLine("Co to za chujowa wysokość niby? " + args[2]);
                            return;
                        }
                    } else {
                        Console.WriteLine("Podaj wysokość ziomeczku");
                        return;
                    }
                } else if (args[1] == "-w") {
                    if (args.Length >= 3) {
                        if (int.TryParse(args[2], out int w)) {
                            width = w;
                        } else {
                            Console.WriteLine("Co to za chujowa szerokość niby? " + args[2]);
                        }
                    } else {
                        Console.WriteLine("Podaj szerokość ziomeczku");
                        return;
                    }
                } else {
                    Console.WriteLine("Co to za chujowy parametr niby? " + args[1]);
                    return;
                }
            } else {
                Console.WriteLine("Podaj wysokość albo szerokość ziomeczku\nresizer.exe <path> (-h height | -w width)");
                return;
            }

            if (!Directory.Exists(dir)) {
                Console.WriteLine("Zły folder ziomeczku");
                return;
            }

            if(width.HasValue && width <= 1 || height.HasValue && height <= 1) {
                Console.WriteLine("A weź wypierdalaj");
                return;
            }

            string[] extensions = { ".jpg", ".jpeg" };
            IEnumerable<string> files = Directory.EnumerateFiles(dir, "*.*", SearchOption.AllDirectories).Where(f => extensions.Contains(Path.GetExtension(f).ToLowerInvariant()));

            Console.WriteLine("Znalazłem " + files.Count() + " plików ziomeczku");
            Console.WriteLine("Zaczynam mielić ziomeczku");

            foreach (string file in files)
                ProcessFile(file, height, width);

            Console.WriteLine("Już ziomeczku");
        }

        private static void ProcessFile(string file, int? height, int? width) {
            Console.WriteLine("Skaluję plik " + file + " ziomeczku");

            string postfix;
            if (height != null)
                postfix = "-h" + height.ToString();
            else
                postfix = "-w" + width.ToString();

            string newFile = file.Substring(0, file.LastIndexOf(".")) + postfix + ".jpg";
            ResizeJpg(file, newFile, height, width);
        }

        private static void ResizeJpg(string path, string newPath, int? nHeight, int? nWidth) {
            int height, width;
            using (var input = new Bitmap(path)) {
                if (nHeight != null) {
                    height = nHeight.Value;
                    width = (int)Math.Round(height * input.Width / (double)input.Height);
                } else {
                    width = nWidth.Value;
                    height = (int)Math.Round(width * input.Height / (double)input.Width);
                }
                using (var result = new Bitmap(width, height)) {
                    using (Graphics g = Graphics.FromImage(result)) {
                        g.DrawImage(input, 0, 0, width, height);
                    }

                    var ici = ImageCodecInfo.GetImageEncoders().FirstOrDefault(ie => ie.MimeType == "image/jpeg");
                    var eps = new EncoderParameters(1);
                    eps.Param[0] = new EncoderParameter(Encoder.Quality, 100L);
                    result.Save(newPath, ici, eps);
                }
            }
        }
    }
}
