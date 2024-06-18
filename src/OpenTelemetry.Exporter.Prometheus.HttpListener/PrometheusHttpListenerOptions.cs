// Copyright The OpenTelemetry Authors
// SPDX-License-Identifier: Apache-2.0

using OpenTelemetry.Internal;
using OpenTelemetry.Metrics;

namespace OpenTelemetry.Exporter;

/// <summary>
/// <see cref="PrometheusHttpListener"/> options.
/// </summary>
public class PrometheusHttpListenerOptions
{
    private IReadOnlyCollection<string> uriPrefixes = new[] { "http://localhost:9464/" };
    private MetricReaderTemporalityPreference temporalityPreference = MetricReaderTemporalityPreference.Cumulative;

    /// <summary>
    /// Gets or sets the path to use for the scraping endpoint. Default value: "/metrics".
    /// </summary>
    public string ScrapeEndpointPath { get; set; } = "/metrics";

    /// <summary>
    /// Gets or sets a value indicating whether addition of _total suffix for counter metric names is disabled. Default value: <see langword="false"/>.
    /// </summary>
    public bool DisableTotalNameSuffixForCounters { get; set; }

    /// <summary>
    /// Gets or sets the temporality preference for the metric reader.
    /// </summary>
    public MetricReaderTemporalityPreference TemporalityPreference
    {
        get => this.temporalityPreference;
        set
        {
            Guard.ThrowIfNull(value);
            this.temporalityPreference = value;
        }
    }

    /// <summary>
    /// Gets or sets the URI (Uniform Resource Identifier) prefixes to use for the http listener.
    /// Default value: <c>["http://localhost:9464/"]</c>.
    /// </summary>
    public IReadOnlyCollection<string> UriPrefixes
    {
        get => this.uriPrefixes;
        set
        {
            Guard.ThrowIfNull(value);

            if (value.Count == 0)
            {
                throw new ArgumentException("Empty list provided.", nameof(this.UriPrefixes));
            }

            this.uriPrefixes = value;
        }
    }
}
