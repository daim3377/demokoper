   M S B A M L   `   `   `  ����C  ?FastDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:FastDemoFastDemo  5      9!clr-namespace:FastDemo.ViewModelsFastDemo.ViewModels  5          FastDemo.LoginWindow   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:FastDemo     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      8
viewmodels!clr-namespace:FastDemo.ViewModels     5        � Title$  Вход��5	      $	��400��5
      $	��220��5      .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��Логин:��6   �� 5   
   $��1��6   ��6   �� *Login+ �� Mode$ OneWayToSource=��� 5   
   $��2��6   $��Пароль:��6!   �� 5   
   $��3��6   ��6   �� *
Password+$ OneWayToSource=��� 5   
   $��4��5      $��3q�5      $��
Войти��5      ��5      �� *AuthCommand+$ OneTime=�5      �� 5    
   $��5��5!      $��3q�5"      $,��&Сбросить базу данных��5$      ��5#      �� *RegenCommand+$ OneTime=�5$      5%      5&      