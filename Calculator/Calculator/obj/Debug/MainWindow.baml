   M S B A M L   `   `   `  ����E  ACalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Calculator
Calculator  5   	       Calculator.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Calculator     5   	     � Title$  
MainWindow��5   	   $	��500��6   $	��500��6)    � 	Resources 5	       �� 
TargetType �� Property �� Value��%�   '��       �� 5
   
   " ��6   .�5      ��  � ��$ 26(�6)   �� 5       � ��$ Normal"�6+   �� 5       � ��$ 2,2,2,2q�6'   �� 5       � ��$ 1,1,3,3q�60   6B   -   5        5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $��6* �6   .+�5   
   �� -   5         ��Name$ 
ScoreBoard��5      $��3,3,1,1q�6%   
����� �$��Stretch=�5   $   
������� �� Padding$ 5,0,5,0q�5   (   $��2,3,2,2q�6:   ._�5      �� -   5         ��Name$ Digits��5      	 �� TextAlignment$	 Right=�6&   $��	 2345,344��6<   $��40(�5      
 � UseLayoutRounding
 .  $��Bottom=�5       � IsSharedSizeScope . $��Normal"�5      $��Disabled=�5      $��Stretch=�5       $��0,0,0,5q�67   5!      A� 5"   
   $��1��6    A� Columns$ 4��6#    A� Rows$ 6��6/   $��0,0,0,1q�68   .+�5%      �� 
�������$��%��6,   �� 5&      
�������$��CE��6,   �� 5'      
�������$��C��6,   �� 5(      
�������$��*=��6,   �� 5)      
�������$	��1/X��6,   �� 5*      
�������$	��X^2��6,   �� 5+      
�������$��x^(1/2)��6,   �� 5,      
�������$��/��6,   �� 5.      
�������$��7��6(   �� 5/      
�������$��8��6(   �� 50      
�������$��9��6(   �� 52      
�������$��*��6,   �� 54      
�������$��4��6(   �� 55      
�������$��5��6(   �� 56      
�������$��6��6(   �� 58      
�������$��-��6,   �� 5:      
�������$��1��6(   �� 5;      
�������$��2��6(   �� 5<      
�������$��3��6(   �� 5>      
�������$��+��6,   �� 5@      
�������$	��+/-��6(   �� 5A      
�������$��0��6(   �� 5B      
�������$��,��6(   �� 5D      
�������$��=��6,   5F      5G      5H      