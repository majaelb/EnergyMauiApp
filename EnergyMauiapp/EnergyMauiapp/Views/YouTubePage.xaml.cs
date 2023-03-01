using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using YoutubeExplode.Videos.Streams;
using YoutubeExplode;
using CommunityToolkit.Maui.Views;
using EnergyMauiapp.Models;
using EnergyMauiapp.ViewModels;

namespace EnergyMauiapp.Views;

public partial class YouTubePage : ContentPage
{
    YouTubePageViewModel vm = new();

    public YouTubePage()
    {
        InitializeComponent();
        BindingContext = vm;
    }
    private async void GetVideoContent(object sender, EventArgs e)
    {
        var service = new YouTubeService(new BaseClientService.Initializer()
        {
            ApiKey = "AIzaSyCDRz0y5NHzkhHaD6zxlNXa7beiK0lJ_ww"
        });

        var searchListRequest = service.Search.List("snippet");
        if (sender == StressButton)
            searchListRequest.Q = "Meditation " + StressButton.Text;
        if (sender == AnxietyButton)
            searchListRequest.Q = "Meditation " + AnxietyButton.Text;
        if (sender == SleepButton)
            searchListRequest.Q = "Meditation " + SleepButton.Text;

        searchListRequest.RegionCode = "se";
        searchListRequest.MaxResults = 3;

        var results = await searchListRequest.ExecuteAsync();

        //TODO: Listview/collectionview för att visa mediaelements?

        YoutubeClient youtube = new();

        //Video1
        StreamManifest streamManifest0 = await youtube.Videos.Streams.GetManifestAsync("https://www.youtube.com/watch?v=" + results.Items[0].Id.VideoId);
        IVideoStreamInfo streamInfo0 = streamManifest0.GetMuxedStreams().GetWithHighestVideoQuality();
        if (streamInfo0 != null)
        {
            // Get the actual stream
            Stream stream = await youtube.Videos.Streams.GetAsync(streamInfo0);

            mediaElement0.Source = streamInfo0.Url;
        }

        //video2
        StreamManifest streamManifest1 = await youtube.Videos.Streams.GetManifestAsync("https://www.youtube.com/watch?v=" + results.Items[1].Id.VideoId);
        IVideoStreamInfo streamInfo1 = streamManifest1.GetMuxedStreams().GetWithHighestVideoQuality();
        if (streamInfo1 != null)
        {
            // Get the actual stream
            Stream stream = await youtube.Videos.Streams.GetAsync(streamInfo1);

            mediaElement1.Source = streamInfo1.Url;
        }

        //video3
        StreamManifest streamManifest2 = await youtube.Videos.Streams.GetManifestAsync("https://www.youtube.com/watch?v=" + results.Items[2].Id.VideoId);
        IVideoStreamInfo streamInfo2 = streamManifest2.GetMuxedStreams().GetWithHighestVideoQuality();
        if (streamInfo1 != null)
        {
            // Get the actual stream
            Stream stream = await youtube.Videos.Streams.GetAsync(streamInfo2);

            mediaElement2.Source = streamInfo2.Url;
        }



    }
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}