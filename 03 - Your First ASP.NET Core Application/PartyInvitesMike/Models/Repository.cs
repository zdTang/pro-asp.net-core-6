using System.Collections.Generic;

namespace PartyInvitesMike.Models
{
    public static class Repository
    {
        private static List<GuestResponse> responses = new();
        //Read-only property
        public static IEnumerable<GuestResponse> Responses => responses;
        public static void AddResponse(GuestResponse response)
        {
            Console.WriteLine(response);
            responses.Add(response);
        }
    }
}