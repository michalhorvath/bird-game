using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

public class NotificationManager
{

    public static void init(){
        var channel = new AndroidNotificationChannel()
        {
            Id = "bird_channel",
            Name = "Bird Channel",
            Importance = Importance.Default,
            Description = "Bird arrival notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    public static void scheduleAndroidNotification(float seconds){
        var notification = new AndroidNotification();
        notification.Title = "Bird has arrived!";
        notification.Text = "See your loot now.";
        notification.FireTime = System.DateTime.Now.AddSeconds(seconds);
        AndroidNotificationCenter.SendNotification(notification, "bird_channel");
    }

}
