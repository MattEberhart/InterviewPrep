using InterviewPrep;

namespace IntervewPrepTests;

public class BlockFileTableTests
{
    [Test]
    public void GetFileBytes_MultiFileWithUnused()
    {
        var blocks = new Block[]
        {
            new Block { InUse = true, Bytes = new byte[] { 0x41, 0x42 }, Next = 7, Name = "FileName1" },
            new Block { InUse = false },
            new Block { InUse = false },
            new Block { InUse = false },
            new Block { InUse = false },
            new Block { InUse = true, Bytes = new byte[] { 0x43, 0x44 }, Next = 13, Name = "FileName2" },
            new Block { InUse = true, Bytes = new byte[] { 0x45, 0x46 }, Next = 0 }, // FileName1
            new Block { InUse = false },
            new Block { InUse = false },
            new Block { InUse = true, Bytes = new byte[] { 0x47, 0x48 }, Next = 0, Name = "FileName3" }, // Single block
            new Block { InUse = false },
            new Block { InUse = false },
            new Block { InUse = true, Bytes = new byte[] { 0x49, 0x50 }, Next = 0 }, // FileName2
        };
        
        var blockFileTable = new BlockFileTable(blocks);

        var fileBytes = blockFileTable.GetFileBytes("FileName1");
        Assert.AreEqual(new byte[] { 0x41, 0x42, 0x45, 0x46 }, fileBytes);
        
        fileBytes = blockFileTable.GetFileBytes("FileName2");
        Assert.AreEqual(new byte[] { 0x43, 0x44, 0x49, 0x50 }, fileBytes);
        
        fileBytes = blockFileTable.GetFileBytes("FileName3");
        Assert.AreEqual(new byte[] { 0x47, 0x48 }, fileBytes);
    }

    [Test]
    public void GetFileByes_UnusedBlocks()
    {
        var blocks = new Block[]
        {
            new Block { InUse = false },
            new Block { InUse = false },
            new Block { InUse = false },
            new Block { InUse = false }
        };
        
        var blockFileTable = new BlockFileTable(blocks);
        Assert.AreEqual(0, blockFileTable.FileCount());
    }
    
    [Test]
    public void GetFileByes_NoBlocks()
    {
        var blocks = new Block[] { };
        
        var blockFileTable = new BlockFileTable(blocks);
        Assert.AreEqual(0, blockFileTable.FileCount());
    }
    
    [Test]
    public void GetFileBytes_SingleFile()
    {
        var blocks = new Block[]
        {
            new Block { InUse = true, Bytes = new byte[] { 0x41, 0x42 }, Next = 2, Name = "FileName" },
            new Block { InUse = true, Bytes = new byte[] { 0x43, 0x44 }, Next = 0 }
        };
        var blockFileTable = new BlockFileTable(blocks);
        
        var fileBytes = blockFileTable.GetFileBytes("FileName");
        
        Assert.AreEqual(new byte[] { 0x41, 0x42, 0x43, 0x44 }, fileBytes);
    }

    [Test]
    public void GetFileBytes_SingleBlock()
    {
        var blocks = new Block[]
        {
            new Block { InUse = true, Bytes = new byte[] { 0x41, 0x42 }, Next = 0, Name = "FileName" }
        };
        var blockFileTable = new BlockFileTable(blocks);
        
        var fileBytes = blockFileTable.GetFileBytes("FileName");
        
        Assert.AreEqual(new byte[] { 0x41, 0x42 }, fileBytes);
    }
    
    [Test]
    public void GetFileBytes_NonExistingFile_ThrowsArgumentException()
    {
        var blocks = new Block[]
        {
            new Block { InUse = true, Bytes = new byte[] { 0x41, 0x42 }, Next = 2, Name = "FileName" },
            new Block { InUse = true, Bytes = new byte[] { 0x43, 0x44 }, Next = 0 }
        };
        var blockFileTable = new BlockFileTable(blocks);
        
        Assert.Throws<ArgumentException>(() => blockFileTable.GetFileBytes("nonExistingFile"));
    }
}