   M S B A M L   `   `   `  ����A  =TPA_ES, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:TPA_ES.View.SecurityMaintenanceViews$TPA_ES.View.SecurityMaintenanceViews  5   	   B    <TPA_ES.View.SecurityMaintenanceViews.SecurityMaintenanceView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Dlocal2clr-namespace:TPA_ES.View.SecurityMaintenanceViews     5   	     � Title$  SecurityMaintenanceView��5   	   $��519.6��6)   $��874.4��68   .��5	      � $��15q�6   
���� K� � ColumnDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��Schedule for Maintenance��6   $��0��64   $��0��6A   $��2��6Q   $��25(�5      $
��Bold"�6"   $��Center=�64    �� Padding$ 10q�6Q   
�������5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��dgItem��5         AutoGenerateColumns .  
���� K�$��2��5      $��1��6    $��25,10.4,10.6,39q�60   $��3q�6I   ��5      ��  �� Path$ 
ReportList� �� Mode$ TwoWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn   Header$ 	Report Id��5!      	   Width5  /System.Windows.Controls.DataGridLengthConverter$
	 auto 6(   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 5"      �� $ Id�  5#      $ 	Item Code��5$      $
	 auto 6(   
 5%      �� $ ItemCode�  5&      $ Description��5'      $
	 auto 6*   
 5(      �� $ Description�  5)      $ Report Date��5*      $
	 auto 6*   
 5+      �� $ 
ReportDate�  5,      $ Repair Date��5-      $
	 auto 6*   
 5.      �� $ 
RepairDate�  5/      $ Repair Status��50      $
	 auto 6,   
 51      �� $ ReportStatus�53      �� 5K   
   -   5        $��backBtn��5K      $
��Back��6    $��1��6/   $��0��6?   $��25,45,733.6,9.8q�5L      $��8q�6*   $��15(�66   
����� �5M   1   5N      5O      