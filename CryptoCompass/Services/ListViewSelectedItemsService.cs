﻿using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace CryptoCompass.Services
{
    public static class ListViewSelectedItemsService
    {
        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.RegisterAttached(
                "SelectedItems",
                typeof(IList),
                typeof(ListViewSelectedItemsService),
                new PropertyMetadata(null, OnSelectedItemsChanged));

        public static void SetSelectedItems(DependencyObject element, IList value)
        {
            element.SetValue(SelectedItemsProperty, value);
        }

        public static IList GetSelectedItems(DependencyObject element)
        {
            return (IList)element.GetValue(SelectedItemsProperty);
        }

        private static void OnSelectedItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ListView listView)
            {
                listView.SelectionChanged -= ListView_SelectionChanged;

                if (e.NewValue is IList newList)
                {
                    foreach (var item in listView.SelectedItems)
                    {
                        if (!newList.Contains(item))
                        {
                            newList.Add(item);
                        }
                    }
                }

                listView.SelectionChanged += ListView_SelectionChanged;
            }
        }

        private static void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ListView listView)
            {
                var selectedItems = GetSelectedItems(listView);

                if (selectedItems == null) return;

                foreach (var item in e.RemovedItems)
                {
                    selectedItems.Remove(item);
                }

                foreach (var item in e.AddedItems)
                {
                    selectedItems.Add(item);
                }
            }
        }
    }
}
