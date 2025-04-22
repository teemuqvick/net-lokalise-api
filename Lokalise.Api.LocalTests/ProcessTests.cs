using System;
using System.Text;
using System.Threading.Tasks;
using Lokalise.Api.Models;
using Xunit;

namespace Lokalise.Api.LocalTests;

public class ProcessTests : LocalTests
{
    [Fact]
    public async Task RetrieveProcess_JsonStringShouldRetrieve()
    {
        // Arrange
        var testProject = await EnsureTestProjectAsync();

        Assert.NotNull(testProject.ProjectId);

        var uploadResult = await LokaliseClient.Files.UploadAsync(testProject.ProjectId!, Convert.ToBase64String(Encoding.UTF8.GetBytes("{ \"key\": \"value\" }")), "test-file.json", "en");

        Assert.NotNull(uploadResult);
        Assert.Equal(uploadResult!.ProjectId, testProject.ProjectId);
        Assert.NotNull(uploadResult.Location);
        Assert.NotNull(uploadResult.Process);

        await Task.Delay(TimeSpan.FromSeconds(5));

        // Act
        var exportProcess = await LokaliseClient.Files.StartExportAsync(testProject.ProjectId!, "json");
        ProcessInformation? processInformation = null;
        const int maxTryCount = 5;
        var tryCount = 0;
        while (tryCount < maxTryCount || processInformation!.Process!.Status != Process.StatusFinished)
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            processInformation = await LokaliseClient.Processes.RetrieveProcessAsync(testProject.ProjectId!, exportProcess!.ProcessId!);
            tryCount++;
        }
                
        // Assert
        Assert.NotNull(processInformation);
        Assert.Equal(testProject.ProjectId, processInformation.ProjectId);
        Assert.NotNull(processInformation.Process);
        Assert.Equal("file-import", processInformation.Process!.Type);
        Assert.NotNull(processInformation.Process.Details?.DownloadUrl);
    }
}