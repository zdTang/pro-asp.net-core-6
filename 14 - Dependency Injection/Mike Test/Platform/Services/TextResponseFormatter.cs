namespace Platform.Services {
    public class TextResponseFormatter : IResponseFormatter {
        private int responseCounter = 0;
        private static TextResponseFormatter? shared;

        /// <summary>
        /// Notice here, the "Context" will not rely on this class
        /// Which means parameters of a methods are not taken granted to came from this Type or Instance
        /// They can totally came from other Context 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="content"></param>
        public async Task Format(HttpContext context, string content) {
            await context.Response.
                WriteAsync($"Response {++responseCounter}:\n{content}");
        }

        public static TextResponseFormatter Singleton
        {
            get { return shared ?? (shared = new TextResponseFormatter()); }
        }
    }
}
