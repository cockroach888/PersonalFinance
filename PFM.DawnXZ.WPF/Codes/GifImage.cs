using System;
using System.Net;
using System.IO;
using System.Security;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Windows.Resources;

namespace PFM.DawnXZ.WPF.Codes
{
    /// <summary>
    /// 
    /// </summary>
    public class GifImageExceptionRoutedEventArgs : RoutedEventArgs
    {
        public Exception ErrorException;

        public GifImageExceptionRoutedEventArgs(RoutedEvent routedEvent, object obj)
            : base(routedEvent, obj)
        {
        }
    }
    /// <summary>
    /// 
    /// </summary>
    class WebReadState
    {
        public WebRequest webRequest;
        public MemoryStream memoryStream;
        public Stream readStream;
        public byte[] buffer;
    }
    /// <summary>
    /// 
    /// </summary>
    public class GifImage : System.Windows.Controls.UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        private GifAnimation gifAnimation = null;
        /// <summary>
        /// 
        /// </summary>
        private Image image = null;
        /// <summary>
        /// 
        /// </summary>
        public GifImage()
        {  }
        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty ForceGifAnimProperty = DependencyProperty.Register("ForceGifAnim", typeof(bool), typeof(GifImage), new FrameworkPropertyMetadata(false));
        /// <summary>
        /// 
        /// </summary>
        public bool ForceGifAnim
        {
            get
            {
                return (bool)this.GetValue(ForceGifAnimProperty);
            }
            set
            {
                this.SetValue(ForceGifAnimProperty, value);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(string), typeof(GifImage), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OnSourceChanged)));
        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            GifImage obj = (GifImage)d;
            string s = (string)e.NewValue;
            obj.CreateFromSourceString(s);
        }
        /// <summary>
        /// 
        /// </summary>
        public string Source
        {
            get
            {
                return (string)this.GetValue(SourceProperty);
            }
            set
            {
                this.SetValue(SourceProperty, value);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty StretchProperty = DependencyProperty.Register("Stretch", typeof(Stretch), typeof(GifImage), new FrameworkPropertyMetadata(Stretch.Fill, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(OnStretchChanged)));
        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnStretchChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            GifImage obj = (GifImage)d;
            Stretch s = (Stretch)e.NewValue;
            if (obj.gifAnimation != null)
            {
                obj.gifAnimation.Stretch = s;
            }
            else if (obj.image != null)
            {
                obj.image.Stretch = s;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public Stretch Stretch
        {
            get
            {
                return (Stretch)this.GetValue(StretchProperty);
            }
            set
            {
                this.SetValue(StretchProperty, value);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty StretchDirectionProperty = DependencyProperty.Register("StretchDirection", typeof(StretchDirection), typeof(GifImage), new FrameworkPropertyMetadata(StretchDirection.Both, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(OnStretchDirectionChanged)));
        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnStretchDirectionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            GifImage obj = (GifImage)d;
            StretchDirection s = (StretchDirection)e.NewValue;
            if (obj.gifAnimation != null)
            {
                obj.gifAnimation.StretchDirection = s;
            }
            else if (obj.image != null)
            {
                obj.image.StretchDirection = s;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public StretchDirection StretchDirection
        {
            get
            {
                return (StretchDirection)this.GetValue(StretchDirectionProperty);
            }
            set
            {
                this.SetValue(StretchDirectionProperty, value);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public delegate void ExceptionRoutedEventHandler(object sender, GifImageExceptionRoutedEventArgs args);
        /// <summary>
        /// 
        /// </summary>
        public static readonly RoutedEvent ImageFailedEvent = EventManager.RegisterRoutedEvent("ImageFailed", RoutingStrategy.Bubble, typeof(ExceptionRoutedEventHandler), typeof(GifImage));
        /// <summary>
        /// 
        /// </summary>
        public event ExceptionRoutedEventHandler ImageFailed
        {
            add
            {
                AddHandler(ImageFailedEvent, value);
            }
            remove
            {
                RemoveHandler(ImageFailedEvent, value);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            RaiseImageFailedEvent(e.ErrorException);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exp"></param>
        void RaiseImageFailedEvent(Exception exp)
        {
            GifImageExceptionRoutedEventArgs newArgs = new GifImageExceptionRoutedEventArgs(ImageFailedEvent, this);
            newArgs.ErrorException = exp;
            RaiseEvent(newArgs);
        }
        /// <summary>
        /// 
        /// </summary>
        private void DeletePreviousImage()
        {
            if (image != null)
            {
                this.RemoveLogicalChild(image);
                image = null;
            }
            if (gifAnimation != null)
            {
                this.RemoveLogicalChild(gifAnimation);
                gifAnimation = null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void CreateNonGifAnimationImage()
        {
            image = new Image();
            image.ImageFailed += new EventHandler<ExceptionRoutedEventArgs>(image_ImageFailed);
            ImageSource src = (ImageSource)(new ImageSourceConverter().ConvertFromString(Source));
            image.Source = src;
            image.Stretch = Stretch;
            image.StretchDirection = StretchDirection;
            this.AddChild(image);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="memoryStream"></param>
        private void CreateGifAnimation(MemoryStream memoryStream)
        {
            gifAnimation = new GifAnimation();
            gifAnimation.CreateGifAnimation(memoryStream);
            gifAnimation.Stretch = Stretch;
            gifAnimation.StretchDirection = StretchDirection;
            this.AddChild(gifAnimation);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        private void CreateFromSourceString(string source)
        {
            DeletePreviousImage();
            Uri uri;

            try
            {
                uri = new Uri(source, UriKind.RelativeOrAbsolute);
            }
            catch (Exception exp)
            {
                RaiseImageFailedEvent(exp);
                return;
            }

            if (source.Trim().ToUpper().EndsWith(".GIF") || ForceGifAnim)
            {
                if (!uri.IsAbsoluteUri)
                {
                    GetGifStreamFromPack(uri);
                }
                else
                {

                    string leftPart = uri.GetLeftPart(UriPartial.Scheme);

                    if (leftPart == "http://" || leftPart == "ftp://" || leftPart == "file://")
                    {
                        GetGifStreamFromHttp(uri);
                    }
                    else if (leftPart == "pack://")
                    {
                        GetGifStreamFromPack(uri);
                    }
                    else
                    {
                        CreateNonGifAnimationImage();
                    }
                }
            }
            else
            {
                CreateNonGifAnimationImage();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="memoryStream"></param>
        private delegate void WebRequestFinishedDelegate(MemoryStream memoryStream);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="memoryStream"></param>
        private void WebRequestFinished(MemoryStream memoryStream)
        {
            CreateGifAnimation(memoryStream);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exp"></param>
        private delegate void WebRequestErrorDelegate(Exception exp);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exp"></param>
        private void WebRequestError(Exception exp)
        {
            RaiseImageFailedEvent(exp);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="asyncResult"></param>
        private void WebResponseCallback(IAsyncResult asyncResult)
        {
            WebReadState webReadState = (WebReadState)asyncResult.AsyncState;
            WebResponse webResponse;
            try
            {
                webResponse = webReadState.webRequest.EndGetResponse(asyncResult);
                webReadState.readStream = webResponse.GetResponseStream();
                webReadState.buffer = new byte[100000];
                webReadState.readStream.BeginRead(webReadState.buffer, 0, webReadState.buffer.Length, new AsyncCallback(WebReadCallback), webReadState);
            }
            catch (WebException exp)
            {
                this.Dispatcher.Invoke(DispatcherPriority.Render, new WebRequestErrorDelegate(WebRequestError), exp);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="asyncResult"></param>
        private void WebReadCallback(IAsyncResult asyncResult)
        {
            WebReadState webReadState = (WebReadState)asyncResult.AsyncState;
            int count = webReadState.readStream.EndRead(asyncResult);
            if (count > 0)
            {
                webReadState.memoryStream.Write(webReadState.buffer, 0, count);
                try
                {
                    webReadState.readStream.BeginRead(webReadState.buffer, 0, webReadState.buffer.Length, new AsyncCallback(WebReadCallback), webReadState);
                }
                catch (WebException exp)
                {
                    this.Dispatcher.Invoke(DispatcherPriority.Render, new WebRequestErrorDelegate(WebRequestError), exp);
                }
            }
            else
            {
                this.Dispatcher.Invoke(DispatcherPriority.Render, new WebRequestFinishedDelegate(WebRequestFinished), webReadState.memoryStream);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        private void GetGifStreamFromHttp(Uri uri)
        {
            try
            {
                WebReadState webReadState = new WebReadState();
                webReadState.memoryStream = new MemoryStream();
                webReadState.webRequest = WebRequest.Create(uri);
                webReadState.webRequest.Timeout = 10000;

                webReadState.webRequest.BeginGetResponse(new AsyncCallback(WebResponseCallback), webReadState);
            }
            catch (SecurityException)
            {
                CreateNonGifAnimationImage();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        private void ReadGifStreamSynch(Stream s)
        {
            byte[] gifData;
            MemoryStream memoryStream;
            using (s)
            {
                memoryStream = new MemoryStream((int)s.Length);
                BinaryReader br = new BinaryReader(s);
                gifData = br.ReadBytes((int)s.Length);
                memoryStream.Write(gifData, 0, (int)s.Length);
                memoryStream.Flush();
            }
            CreateGifAnimation(memoryStream);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        private void GetGifStreamFromPack(Uri uri)
        {
            try
            {
                StreamResourceInfo streamInfo;

                if (!uri.IsAbsoluteUri)
                {
                    streamInfo = Application.GetContentStream(uri);
                    if (streamInfo == null)
                    {
                        streamInfo = Application.GetResourceStream(uri);
                    }
                }
                else
                {
                    if (uri.GetLeftPart(UriPartial.Authority).Contains("siteoforigin"))
                    {
                        streamInfo = Application.GetRemoteStream(uri);
                    }
                    else
                    {
                        streamInfo = Application.GetContentStream(uri);
                        if (streamInfo == null)
                        {
                            streamInfo = Application.GetResourceStream(uri);
                        }
                    }
                }
                if (streamInfo == null)
                {
                    throw new FileNotFoundException("Resource not found.", uri.ToString());
                }
                ReadGifStreamSynch(streamInfo.Stream);
            }
            catch (Exception exp)
            {
                RaiseImageFailedEvent(exp);
            }
        }
    }
}
