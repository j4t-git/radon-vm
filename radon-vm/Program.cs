﻿namespace radon_vm {
    internal class Program {
        private static void Main(string[] args) {
            string inputPath = args[0];
            string? inputDir = Path.GetDirectoryName(inputPath);

            if (string.IsNullOrEmpty(inputDir)) {
                return;
            }
            
            string outputDir = Path.Combine(inputDir, "Protected");
            string outputPath = Path.Combine(outputDir, Path.GetFileName(inputPath));


            try {
                Directory.CreateDirectory(outputDir);
    
                File.Copy(inputPath, outputPath, true);
    
                Compiler compiler = new Compiler(outputPath);
                compiler.Protect();
                compiler.Save();
        } catch (Exception e) {
                Console.WriteLine($"File error: {e.Message}");
    }
}
