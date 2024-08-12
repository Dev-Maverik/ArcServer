using VPM.Application.Interfaces;
using VPM.Application.Models;

namespace VPM.Application.Services
{

    public class StreamService : IStreamService
    {

        #region Declaration

        StreamManager streamManager;

        #endregion

        #region Ctor

        public StreamService()
        {
            streamManager = new StreamManager();
        }

        #endregion

        #region Methods

        public string GetStreamUrl(string url)
        {
            string responseUrl = string.Empty;

            try
            {
                if (streamManager.CreatePipe(url))
                {
                    StremMapping? mapping = streamManager.GetMapping(url);

                    if (mapping != null)
                    {
                        streamManager.Play(mapping.PipeLineId);
                        responseUrl = mapping.WebRtcUrl;
                    }
                }
            }
            catch (Exception)
            {
            }

            return responseUrl;
        }

        public bool StartStream(string url)
        {
            bool response = false;

            try
            {
                if (!string.IsNullOrEmpty(url))
                {
                    streamManager.Play(streamManager.GetMapping(url)?.PipeLineId ?? 0);
                    response = true;
                }
            }
            catch (Exception)
            {
            }

            return response;
        }

        public bool PauseStream(string url)
        {
            bool response = false;

            try
            {
                if (!string.IsNullOrEmpty(url))
                {
                    streamManager.Play(streamManager.GetMapping(url)?.PipeLineId ?? 0);
                    response = true;
                }
            }
            catch (Exception)
            {
            }

            return response;
        }

        public bool StopStream(string url)
        {
            bool response = false;

            try
            {
                if (!string.IsNullOrEmpty(url))
                {
                    streamManager.Play(streamManager.GetMapping(url)?.PipeLineId ?? 0);
                    response = true;
                }
            }
            catch (Exception)
            {
            }

            return response;
        }

        #endregion

    }

}