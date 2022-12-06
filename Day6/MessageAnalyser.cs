namespace Day6
{
    public static class MessageAnalyser
    {
        public static int FindEndOfPacketMarker(string buffer)
        {
            return FindEndOfMarker(buffer, markerLength: 4);
        }

        public static int FindEndOfMessageMarker(string buffer)
        {
            return FindEndOfMarker(buffer, markerLength: 14);
        }

        private static int FindEndOfMarker(string buffer, int markerLength)
        {
            var markerStartIndex = 0;
            while (markerStartIndex < buffer.Length - markerLength)
            {
                var candidate = buffer.Substring(markerStartIndex, markerLength);
                var allDistinct = candidate.Distinct().Count() == markerLength;

                if (allDistinct)
                    return markerStartIndex + markerLength;

                ++markerStartIndex;
            }

            throw new NotSupportedException("Marker not found");
        }
    }
}