using System.Drawing;

namespace Day7
{
    public static class FilesystemAnalyser
    {
        public class FolderNode
        {
            public static FolderNode CreateRootNode(string name)
            {
                return new FolderNode
                {
                    Name = name,
                    IsDirectory = true,
                    Size = 0,
                    Parent = null
                };
            }
            public static FolderNode CreateDirectoryNode(string name, FolderNode? parent)
            {
                return new FolderNode
                {
                    Name = name,
                    IsDirectory = true,
                    Size = 0,
                    Parent = parent
                };
            }
            public static FolderNode CreateFileNode(string name, int size, FolderNode? parent)
            {
                return new FolderNode
                {
                    Name = name,
                    IsDirectory = false,
                    Size = size,
                    Parent = parent
                };
            }

            public string Name { get; private set; } = "";
            public bool IsDirectory { get; private set; }
            public int Size { get; set; }
            public FolderNode? Parent { get; private set; }
            public List<FolderNode> Children { get; } = new List<FolderNode>();

            public override string? ToString()
            {
                return $"{Name} Children.Count={Children.Count} Parent={Parent?.Name} Size={Size}";
            }
        }

        public static FolderNode CreateFilesystem(string[] terminalOutput)
        {
            FolderNode rootNode = null!;
            FolderNode currentNode = null!;

            foreach(var terminalLine in terminalOutput)
            {
                if (terminalLine == "$ cd /")
                {
                    rootNode = FolderNode.CreateRootNode("/");
                    currentNode = rootNode;
                }
                else if (terminalLine.StartsWith("$ cd "))
                {
                    var folderName = terminalLine.Substring(5);
                    if (folderName == "..")
                    {
                        currentNode = currentNode.Parent!;
                    }
                    else
                    {
                        currentNode = currentNode.Children.First(x => x.Name == folderName);
                    }
                }
                else if (terminalLine.StartsWith("$ ls"))
                {
                }
                else if (terminalLine.StartsWith("dir "))
                {
                    var folderName = terminalLine.Substring(4);
                    var childNode = FolderNode.CreateDirectoryNode(folderName, parent: currentNode);
                    currentNode.Children.Add(childNode);
                }
                else
                {
                    // Size + File
                    var bits = terminalLine.Split(" ");
                    if (bits.Length != 2)
                        throw new NotImplementedException();
                    var size = int.Parse(bits[0]);
                    var filename = bits[1];
                    var childNode = FolderNode.CreateFileNode(filename, size, parent: currentNode);
                    currentNode.Children.Add(childNode);
                }
            }
            return rootNode;
        }

        public static void SetFolderSizes(FolderNode filesystem)
        {
            var currentNode = filesystem;
            foreach(var child in currentNode.Children)
            {
                if (child.IsDirectory)
                {
                    SetFolderSizes(child);
                }
                currentNode.Size += child.Size;
            }
        }

        public static int CalculateTotalSize(FolderNode filesystem, int maxDirectorySize)
        {
            var result = 0;
            CalculateTotalSize(filesystem, maxDirectorySize, ref result);
            return result;
        }

        public static void CalculateTotalSize(FolderNode filesystem, int maxDirectorySize, ref int total)
        {
            var currentNode = filesystem;
            foreach (var child in currentNode.Children)
            {
                if (child.IsDirectory)
                {
                    CalculateTotalSize(child, maxDirectorySize, ref total);

                    if (child.Size <= maxDirectorySize)
                        total += child.Size;
                }
            }
        }
    }
}