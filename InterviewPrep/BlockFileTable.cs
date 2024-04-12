namespace InterviewPrep;

public class BlockFileTable
{
    private readonly Dictionary<string, int> _fileStartMap;
    private readonly Block[] _blocks;
    
    public BlockFileTable(Block[] blocks)
    {
        _blocks = blocks;
        _fileStartMap = GetBlockFileStarts(_blocks);
    }

    public byte[] GetFileBytes(string name)
    {
        if (!_fileStartMap.TryGetValue(name, out var blockId))
        {
            throw new ArgumentException($"File with name: {name} does not exist");
        }

        // Subtract one because block id starts at one.
        var startBlockIndices = _fileStartMap[name] - 1;
        var currentBlock = _blocks[startBlockIndices];
        var filesBytes = currentBlock.Bytes.ToList();

        while (currentBlock.Next != 0)
        {
            currentBlock = _blocks[currentBlock.Next - 1];
            filesBytes = filesBytes.Concat(currentBlock.Bytes).ToList();
        }

        return filesBytes.ToArray();
    }

    public int FileCount()
    {
        return _fileStartMap.Count;
    }
    
    private Dictionary<string, int> GetBlockFileStarts(Block[] blocks)
    {
        // Default all blocks to be starting blocks - represented by true.
        var fileStartIndices = Enumerable.Repeat(true, blocks.Length).ToArray();
        
        // Set blocks that are not be starting blocks to 0.
        for(int i = 0; i < blocks.Length; i++)
        {
            // If current block not in use it is not a start of a file.
            if (!blocks[i].InUse)
            {
                fileStartIndices[i] = false;
            }

            // Any block that is a next block is not a start of a file.
            if (blocks[i].Next != 0)
            {
                // Next - 1 because blocks start at 1. 0 represents end of file.
                fileStartIndices[blocks[i].Next - 1] = false;
            }
        }
        
        // Create Table of starting blocks, names are new guids
        Dictionary<string, int> startingBlocks = new Dictionary<string, int>();

        for (int i = 0; i < fileStartIndices.Length; i++)
        {
            if (fileStartIndices[i])
            {
                // Name is new Guid
                // Block Id is indices + 1 because block id starts at 1. 0 is end of file.
                startingBlocks.Add(_blocks[i].Name, i + 1);
            }
        }

        return startingBlocks;
    }

    private Block GetBlock(int blockId)
    {
        // Only block ids for as many blocks as there are.
        // Block id starts at 1.
        if (blockId > _blocks.Length || blockId == 0)
        {
            throw new ArgumentException("Invalid block id.");
        }

        return _blocks[blockId];
    }
}