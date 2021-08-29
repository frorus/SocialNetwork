using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.PLL.Views
{
    public class UserFriendView
    {
        public void Show(IEnumerable<Friend> friends)
        {
            Console.WriteLine("\nМои друзья:");

            if (friends.Count() == 0)
            {
                Console.WriteLine("У вас нет друзей\n");
                return;
            }

            friends.ToList().ForEach(friend =>
            {
                Console.WriteLine(friend.FriendEmail);
            });
        }
    }
}