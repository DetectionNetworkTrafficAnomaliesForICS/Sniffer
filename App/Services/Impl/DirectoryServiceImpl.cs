using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Storage;
using Directory = Sniffer.Models.Directory;

namespace Sniffer.Services.Impl;

public class DirectoryServiceImpl : IDirectoryService
{
    public async Task<Directory> PickDirectory()
    {
        try
        {
            await Permissions.RequestAsync<Permissions.StorageRead>();
            await Permissions.RequestAsync<Permissions.StorageWrite>();

            var folderPickerResult = await FolderPicker.Default.PickAsync(CancellationToken.None);
            if (!folderPickerResult.IsSuccessful)
                return null;

            var folderPath = folderPickerResult.Folder.Path;

            return new Directory(folderPath);
        }
        catch (Exception)
        {
            await Toast.Make("No folder picked").Show(CancellationToken.None);
        }

        return null;
    }
}