   M S B A M L   `   `   `  ����M  ITextBoxInputScopes, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:TextBoxInputScopesTextBoxInputScopes  5   	   #    TextBoxInputScopes.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:TextBoxInputScopes     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5
       �� 
TargetType �� Property �� Value��%=  '��       '�� �     �� 5   
   " ��6   .�5      ��  � ��$ 24(�6)   �� 5       � ��$ Center=�62   �� 5       � ��$ 6q�6'   5      �� 5   
   " ��6   .�5      ��  � ��$	 320��6&   �� 5       � ��$ Center=�62   �� 5       � ��$	 0 6q�6'   5      5      .��5      � .+�5   
   � $��Center=�6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5       $
��Auto �6    �� 5!      $
��Auto �6    �� 5"      $
��Auto �6    �� 5#      $
��Auto �6    �� 5$      $
��Auto �6     � ColumnDefinitions 5'      �� 5(      $
��Auto �6#   �� 5)      $
��Auto �6#   .+�5,      �� $*��$Multiline (accepts Return, no Wrap):��6   $��0��5-      $��0��6%   �� 5/       �� AcceptsReturn . $��0��50      $��1��6#   �� 52      $(��"Multiline (ignores Return, wraps):��6   $��1��53      $��0��6%   �� 55       �� TextWrapping$
 Wrap=�6   $��1��56      $��1��6#   �� 58      $(��"Multiline (accepts Return, wraps):��6   $��2��59      $��0��6%   �� 5;       . $
 Wrap=�5<      $��2��5=      $��1��6#   �� 5?      $��Default input scope:��6   $��3��5@      $��0��6%   �� 5B      $��3��6   $��1��6#   	 � 
InputScope$	 Default��5C      �� 5E      $ ��Email address input scope:��6   $��4��5F      $��0��6%   �� 5H      $��4��6   $��1��6#   $	 EmailSmtpAddress��5I      �� 5K      $��Number input scope:��6   $��5��5L      $��0��6%   �� 5N      $��5��6   $��1��6#   $	 Number��5O      �� 5Q      $#��Telephone Number input scope:��6   $��6��5R      $��0��6%   �� 5T      $��6��6   $��1��6#   $	 TelephoneNumber��5U      �� 5W      $��URl input scope:��6   $��7��5X      $��0��6%   �� 5Z      $��7��6   $��1��6#   $		 Url��5[      �� 5]      $��PasswordBox:��6   $��9��5^      $��0��6%   G� 5`      $��9��6   $��1��6'   5b      5d      5e      