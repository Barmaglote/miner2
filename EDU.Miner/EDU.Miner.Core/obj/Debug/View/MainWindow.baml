   M S B A M L   `   `   `  ����I  EEDU.Miner.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:EDU.Miner.CoreEDU.Miner.Core  5   	   C&clr-namespace:EDU.Miner.Core.ViewModelEDU.Miner.Core.ViewModel  5   	   E'clr-namespace:EDU.Miner.Core.ConvertersEDU.Miner.Core.Converters  5   	   C&clr-namespace:EDU.Miner.Core.ViewModelEDU.Miner.Core.ViewModel  5	   	       EDU.Miner.Core.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:EDU.Miner.Core     5   	   5vm&clr-namespace:EDU.Miner.Core.ViewModel     5   	   >
converters'clr-namespace:EDU.Miner.Core.Converters     5   	   7game&clr-namespace:EDU.Miner.Core.ViewModel     5	   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5
   	   $	��650��5   !   $	��850��6.     � 
ResizeMode$  NoResize=�6:    � Title 6	   �� *Title+ � TaskbarItemInfo 5      *  $System.Windows.Shell.TaskbarItemInfo  5   
    � DataContext 5      ,  &EDU.Miner.Core.ViewModel.GameViewModel  5   
    � 	Resources 5         	BombImage  
SmileImage,   &EDU.Miner.Core.Converters.BoolInverter  CustomBoolInverter �� 
TargetType  StandardCell �� Property �� Value �� Triggers	 �� Binding
 �� Value �� 
TargetType��%�  &	        &	 4     &	 i     &	 |     �� 5   
   $ ��/Resources/images/bomb.png��6"   �� 5   
   $!��/Resources/images/smile.ico��6#     5   
   6"   �� 5   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��$ 3q�6'    5       �� 5!      	 6   �� *
IsOpened+
 True6;   .a�5"      ��  � ��
 �����63   �� 5#       � ��$ 1q�68   �� 5$       � ��
 �����64   5%      �� 5&      	 6   �� *IsMinedAndOpened+
 True6C   .a�5'      ��  �@�OverridesDefaultStyle . 6>   �� 5(       � �� 5)      �� 5*      " ��6.   .R�5+   "   �� $ ��/Resources/images/bomb.png��6(   $
��Fill=�6L   5,      5.      5/      �� 50      	 6   �� *
IsMarked+
 True6;   .a�51      ��  �@�OverridesDefaultStyle . 6>   �� 52       � �� 53      �� 54      " ��6.   .R�55   "   �� $ ��/Resources/images/flag.png��6(   $
��Fill=�6L   56      58      59      �� 5:      	 6   �� *
IsHidden+
 True6;   .a�5;      ��  � ��
 �����63   �� 5<       � ��$ 1q�68   �� 5=       � ��
 �����64   5>      5@      5A      .��5C      � -   5         �Name$ MainContainer��5C      ��5D   
   �� 5E       j� TileMode$
 Tile=�6    j� Stretch$ Uniform=�6)   .+�5G   
   �� -   5         ��Name$ PlayGrid��5G   K   $��30,80,200,30q�65   ��6   �� *Cells+{�6]   �� *
IsActive+��5H      �� 5I      .R�5J      ��  ��Name$ button��6>   $��15(�6N   #���  6\   ��6   �� *BombsArround+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5K      +  %Microsoft.Xaml.Behaviors.EventTrigger  5L         	EventName$ PreviewMouseLeftButtonUp��6-   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5M   "   2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 68   �� *CellLeftMouseUpCommand+   CommandParameter 6c   �� *Cell+5N        5O      $  PreviewMouseLeftButtonDown��6-   . 5P   "      68   �� *CellLeftMouseDownCommand+ 6e   �� *Cell+5Q        5R      $ PreviewMouseRightButtonUp��6-   . 5S   "      68   �� *CellRightMouseUpCommand+ 6d   �� *Cell+5T        5U      $! PreviewMouseRightButtonDown��6-   . 5V   "      68   �� *CellRightMouseDownCommand+ 6f   �� *Cell+5W      5Y       �� Triggers 5Z      �� 5[      $
 0��6&   	 60   �� a�5\      �� 5]   "    �� 
TargetName$ button��6)    � y�$ Hidden=�6S   5_      5a      ��5c      �� 5d      .R�5e      A�  A� Columns$ 10��6"   5f      5h      � 5i   
   $��53��6   $��
30,22,30,0q�6   $	��Top=�6/    � ColumnDefinitions 5j      �� 5k      �� 5l      �� 5m       � RowDefinitions 5o      .+�5p      �� -   5        $ StartNewGameButton��5p   <   $��1��6   $��40��6%   $��40��60   
�������#��[ 6l   ��6�   ��  �� Path$ StartGameCommand�5q      �� 5r      -   5         ��Name$ MinesMarkedTextBox��5r   @   $��0��6   $	��140��6(   $��40��64   $��28(�6\   $
��Bold"�6j   
������� �� TextAlignment$ Center=�6�   $��Center=�6�   ���	#FFFDD080 �� Padding$ 1q�6   4  .System.Windows.Automation.AutomationProperties   HelpText$: 4Количество ненайденных бомб��6  ��6�   �� *Game.Field.BombsIsLeft+5s      �� 5t      -   5        $ TimeLeftTextBox��5t   @   $��2��6   $	��140��6(   $��40��64   $��28(�6Y   $
��Bold"�6g   
�������$ Center=�6�   $��Center=�6�   ���	#FFFDD080$ 1q�6�   ��6�   �� *TimeIsLeftSeconds+6�   5u      � 5v   
   $
��Left=�6   $	��495��6*   $��650,83,10,0q�67   $	��Top=�6L   .+�5w      &	   System.Windows.Controls.DataGrid	  -   5          	 Name$  RecordsDataGrid��5w   A   ! 	  HeadersVisibility$! Column=�6Z   " 	  
IsReadOnly" . # 	  AutoGenerateColumns# .  $ 	  ColumnWidth5
  /System.Windows.Controls.DataGridLengthConverter$$ *
 6�   $
��Left=�6�   ��6   �� *HistoricalRecords+% 	  Columns% 5x      0  *System.Windows.Controls.DataGridTextColumn  5y      ,  &System.Windows.Controls.DataGridColumn&   Header$
& Date��6)   '   Width$	' 80*
 6P   1  +System.Windows.Controls.DataGridBoundColumn(   Binding( 67   �� *Time+6^     5z      $
& Time��6)   $	' 20*
 6^   ( 67   �� *TotalTimeInSeconds+6l   5|      5}      5~      5      