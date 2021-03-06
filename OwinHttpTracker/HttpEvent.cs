﻿using System;
using System.Runtime.Serialization;
using Microsoft.Owin;

namespace OwinHttpTracker
{
    /// <summary>
    /// Represents an HTTP event that occured in the OWIN pipeline.
    /// </summary>
    [DataContract]
    public sealed class HttpEvent
    {
        [DataMember]
        public Guid TrackingId { get; private set; }
        [DataMember]
        public DateTime Created { get; private set; }

        public HttpEvent()
        {
            TrackingId = Guid.NewGuid();
            Created = DateTime.UtcNow;
        }

        [DataMember]
        public DateTime Requested { get; set; }

        [DataMember]
        public DateTime Responded { get; set; }

        [DataMember]
        public string Verb { get; set; }

        [DataMember]
        public string Host { get; set; }

        [DataMember]
        public string Uri { get; set; }

        [DataMember]
        public long RequestLength { get; set; }

        [DataMember]
        public long ResponseLength { get; set; }

        [DataMember]
        public int Status { get; set; }

        [DataMember]
        public IHeaderDictionary RequestHeaders { get; set; }

        [DataMember]
        public IHeaderDictionary ResponseHeaders { get; set; }

        public static bool IsText(string contentTypeHeader)
        {
            var contentType = new System.Net.Mime.ContentType(contentTypeHeader);
            var mediaType = contentType.MediaType;

            return (
                mediaType.StartsWith("text/") ||
                mediaType.EndsWith("/json") ||
                mediaType.EndsWith("/xml")
            );
        }

        [DataMember]
        public bool EntireRequest { get; set; }

        [DataMember]
        public bool EntireResponse { get; set; }

        #region Not Serialized
        public string Request { get; set; }
        public string Response { get; set; }
        #endregion
    }
}
