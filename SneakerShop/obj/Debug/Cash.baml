   M S B A M L   `   `   `  ����F  BSneakerShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SneakerShopSneakerShop  5          SneakerShop.Cash   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:SneakerShop     5        N� Title$
  Cash��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      $��0.25* �6   �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DataGrid��5      $��0,0,0,65q�6Q   6c     5   
   -   5        $ Zakaz��5      $��2��6"   $��0,0,0,65q�6]   6o   �� 5   
   -   5         ��Name$	 Add��5      $��1��6   $��+��6.   $��Center=�6:   $��0,75,0,0q�6W   $	��Top=�6i   $��65��6�   $��65��6�   $��20(�6�   6�   �� 5   
   -   5        $ Delete��5      $��1��6!   $��-��61   $��Center=�6=   $��	0,251,0,0q�6Z   $	��Top=�6m   $��65��6�   $��65��6�   $��20(�6�   6�   �� 5   
   -   5        $	 Buy��5      $��2��6   $��Оплатить��6.   $
��Left=�6A   $��200,325,0,0q�6\   $	��Top=�6q   $	��200��6�   $��60��6�   6�   �� 5   
   -   5         ��Name$ 
employeecb��5      $
��Left=�6'   $��
80,325,0,0q�6B   $	��Top=�6V   $	��120��6n   �� 5   
   -   5        $ buyercb��5      $
��Left=�6$   $��270,325,0,0q�6?   $	��Top=�6T   $	��120��6l   �� 5   
   $��2��6   $
��Left=�6$   $��
10,325,0,0q�6?   $
��Wrap=�6S   $��Итого:��6g   $	��Top=�6u   �� 5   
   $��2��6   $
��Left=�6$   $��
10,355,0,0q�6?   $
��Wrap=�6S   $��Внесено:��6g   $	��Top=�6w   �� 5   
   -   5         ��Name$	 pay��5      $��2��6   $
��Left=�6/   $��
80,357,0,0q�6J    �� TextWrapping$
 Wrap=�6^   $�� ��6r   $	��Top=�6z   $	��120��6�   �� 5   
   $
��Left=�6   $��
10,329,0,0q�6/   $
��Wrap=�6C   $��Сотрудник��6W   $	��Top=�6h   �� 5   
   $
��Left=�6   $��205,332,0,0q�6/   $
��Wrap=�6D   $��Покупатель��6X   $	��Top=�6j   �� 5   
   -	   5         ��Name$ 	costZakaz��5      $��2��6'   $
��Left=�67   $��140,327,0,0q�6R   $
��Wrap=�6g   $��0��6{   $	��Top=�6�   5!      5"      