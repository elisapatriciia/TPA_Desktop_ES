   M S B A M L   `   `   `  ����A  =TPA_ES, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TPA_ES.ViewTPA_ES.View  5   	   +    %TPA_ES.View.EmployeeLeavingPermitView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:TPA_ES.View     5   	     � Title$  EmployeeLeavingPermitView��5   	   $��429.739��6+   $��866.113��6<   .��5	      � $��15q�6    � ColumnDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   $	��140��6,   �� 5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� -   5        $��btnBack��5      $
��Back��6    $��5,10,38.6,33q�6/   $��3q�6E   
����� �5   0   �� 5   
   $��Employee Leaving Permit��6   $��0��63   $��1��6@   $��2��6P   $��25(�5      $
��Bold"�6"   $��Center=�64    �� Padding$ 10q�6Q   $��49,0,219.8,0q�6^   $	��344��6t   �� 5!   
   $��Employee ID��6   $��1��6'   $��0��64   $��5,7.6,4.6,8.2q�6D   $ 3q�6[   �� 5"   
   $��Leaving Reasons��6   $��3��6+   $��0��68   $��5,8,4.6,7.8q�6H   $ 3q�6]   �� 5#   
   $��Leaving Start Date��6   $��4��6.   $��0��6;   $��5,8,4.6,7.8q�6K   $ 3q�6`   �� 5$   
   $��Leaving End Date��6   $��5��6,   $��0��69   $��5,8,4.6,7.8q�6I   $ 3q�6^   �� 5&   
   -   5        $��txtID��5&      $��1��6   $��1��6,   $��5,0,5.2,7.8q�6<   $��3q�6Q   $��25��5'   R   $��Bottom=�6^   ��6   ��  �� Path$" CurrentEmployeeLP.EmployeeID� �� Mode$ TwoWay=�6^   �� 5(   
   -   5        $��txtLeavingReasons��5(      $��3��6+   $��1��68   $��5.4,8,4.6,7.8q�6H   $��3q�6_   ��5)      �� $ CurrentEmployeeLP.Reason�$ TwoWay=�(  "System.Windows.Controls.DatePicker  5*   
   $��4��6   $��1��6"      SelectedDate 5+      �� $( "CurrentEmployeeLP.LeavingDateStart�$ TwoWay=�  5,   
   $��5��6   $��1��6"    5-      �� $&  CurrentEmployeeLP.LeavingDateEnd�$ TwoWay=��� 50   
   -   5        $��errorMessage��50      $��6��6(   $��1��65   
���  ����6E   �� $ Message�6c   �� 52   
    �� Orientation$ 
Horizontal=�6   $��7��6.   $��1��6;   .+�55      �� -   5        $��	btnUpdate��55      $��Set Leaving Permit��6&   $	��5,8q�6C   $��3q�6P   ��56      �� $ SaveCommand�57      &   System.Windows.Controls.DataGrid  59   
   -   5        $��
dgCustomer��59         AutoGenerateColumns .  $��1��5:      $��2��6    $	��5,8q�60   $��3q�6=   $��7��6I   ��5;      �� $ EmployeeLPList�$ TwoWay=�	   Columns	 5<      0  *System.Windows.Controls.DataGridTextColumn  5=      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Employee Id��5>         Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6*   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5?      �� $ 
EmployeeID�  5@      $
 Reasons��5A      $
 auto 6&    5B      �� $ Reason�  5C      $
 
Start Date��5D      $
 auto 6)    5E      �� $ LeavingDateStart�  5F      $
 End Date��5G      $
 auto 6'    5H      �� $ LeavingDateEnd�5J      5K      5L      