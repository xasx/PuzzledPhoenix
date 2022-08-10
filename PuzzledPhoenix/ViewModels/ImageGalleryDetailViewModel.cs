﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.ComponentModel;

using PuzzledPhoenix.Core.Models;
using PuzzledPhoenix.Core.Services;
using PuzzledPhoenix.Helpers;

using Windows.UI.Xaml.Navigation;

namespace PuzzledPhoenix.ViewModels
{
    public class ImageGalleryDetailViewModel : ObservableObject
    {
        private object _selectedImage;

        public object SelectedImage
        {
            get => _selectedImage;
            set
            {
                SetProperty(ref _selectedImage, value);
                ImagesNavigationHelper.UpdateImageId(ImageGalleryViewModel.ImageGallerySelectedIdKey, ((SampleImage)SelectedImage)?.ID);
            }
        }

        public ObservableCollection<SampleImage> Source { get; } = new ObservableCollection<SampleImage>();

        public ImageGalleryDetailViewModel()
        {
        }

        public async Task LoadDataAsync()
        {
            Source.Clear();

            // Replace this with your actual data
            var data = await SampleDataService.GetImageGalleryDataAsync("ms-appx:///Assets");

            foreach (var item in data)
            {
                Source.Add(item);
            }
        }

        public void Initialize(string selectedImageID, NavigationMode navigationMode)
        {
            if (!string.IsNullOrEmpty(selectedImageID) && navigationMode == NavigationMode.New)
            {
                SelectedImage = Source.FirstOrDefault(i => i.ID == selectedImageID);
            }
            else
            {
                selectedImageID = ImagesNavigationHelper.GetImageId(ImageGalleryViewModel.ImageGallerySelectedIdKey);
                if (!string.IsNullOrEmpty(selectedImageID))
                {
                    SelectedImage = Source.FirstOrDefault(i => i.ID == selectedImageID);
                }
            }
        }
    }
}
