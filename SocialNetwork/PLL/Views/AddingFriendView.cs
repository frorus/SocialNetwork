using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;

namespace SocialNetwork.PLL.Views
{
    public class AddingFriendView
    {
        UserService userService;
        FriendService friendService;

        public AddingFriendView(FriendService friendService, UserService userService)
        {
            this.friendService = friendService;
            this.userService = userService;
        }
        public void Show(User user)
        {
            var userAddingFriendData = new UserAddingFriendData();

            Console.WriteLine("Введите почтовый адрес пользователя, которого хотите добавить в друзья: ");
            userAddingFriendData.FriendEmail = Console.ReadLine();

            userAddingFriendData.UserId = user.Id;

            try
            {
                friendService.AddFriend(userAddingFriendData);

                SuccessMessage.Show("Пользователь успешно добавлен в друзья!");

                user = userService.FindById(user.Id);
            }

            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден");
            }

            catch (Exception)
            {
                AlertMessage.Show("Произоша ошибка при добавлении в друзья");
            }

        }
    }
}