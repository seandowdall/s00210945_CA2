using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace s00210945_CA2
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        //list that is accessible by various methods
        List<Activity> activities;
        List<Activity> filteredActivities = new List<Activity>();
        string selectedItemText;
        int SelectedIndex;
        
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //create some activities
            //three land activities
            Activity a1 = new Activity() { Name = "Hiking", ActivityDate = new DateTime(2021, 06, 01), Cost = 40.00m, Description = "Guided hike through Connemara countryside.", TypeOfActivity = Activity.ActivityType.Land };
            Activity a2 = new Activity() { Name = "Orienteering", ActivityDate = new DateTime(2021, 06, 01), Cost = 80.00m, Description = "Explore the Connemara countryside via map and compass with our orienteering course!", TypeOfActivity = Activity.ActivityType.Land };
            Activity a3 = new Activity() { Name = "Rock Climbing", ActivityDate = new DateTime(2021, 06, 03), Cost = 100.00m, Description = "50 metre rock climbing wall with 4 degress of difficulty.", TypeOfActivity = Activity.ActivityType.Land };

            //three water activitites
            Activity a4 = new Activity() { Name = "Kayaking", ActivityDate = new DateTime(2021, 06, 05), Cost = 20.00m, Description = "Guided beginners white water kayaking.", TypeOfActivity = Activity.ActivityType.Water };
            Activity a5 = new Activity() { Name = "Surfing", ActivityDate = new DateTime(2021, 06, 07), Cost = 120.00m, Description = "Connemara Surf Experience - 1 hour lesson with ex professional surfer.", TypeOfActivity = Activity.ActivityType.Water };
            Activity a6 = new Activity() { Name = "Scuba Diving", ActivityDate = new DateTime(2021, 06, 09), Cost = 400.00m, Description = "Explore the ocean with this all day scuba experience.", TypeOfActivity = Activity.ActivityType.Water };

            //three air activities
            Activity a7 = new Activity() { Name = "Skydiving", ActivityDate = new DateTime(2021, 06, 15), Cost = 620.00m, Description = "Bucket List Skydiving - See Ireland in a whole new way!", TypeOfActivity = Activity.ActivityType.Air };
            Activity a8 = new Activity() { Name = "Hot Air Ballooning", ActivityDate = new DateTime(2021, 06, 23), Cost = 320.00m, Description = "Irelands only A to B hot air balloon experience!", TypeOfActivity = Activity.ActivityType.Air };
            Activity a9 = new Activity() { Name = "Paragliding", ActivityDate = new DateTime(2021, 06, 29), Cost = 700.00m, Description = "Experience a guideded Paraglide with 10 time red bull champion - Nicholas Summers", TypeOfActivity = Activity.ActivityType.Air };

            //add to list
            activities = new List<Activity>();
            activities.Add(a1);
            activities.Add(a2);
            activities.Add(a3);
            activities.Add(a4);
            activities.Add(a5);
            activities.Add(a6);
            activities.Add(a7);
            activities.Add(a8);
            activities.Add(a9);

            //display on screen
            lbxAllActivities.ItemsSource = activities;
        }

        private void LbxAllActivities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //determine what was selected
            Activity selectedActivity = lbxAllActivities.SelectedItem as Activity;


            //null check
            if (selectedActivity != null)
            {
                //take action - display description + cost
                tblkActivityDescription.Text = selectedActivity.GetActivityDescriptionAndCost();
            }

            
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            selectedItemText = lbxAllActivities.SelectedItem.ToString();
            SelectedIndex = lbxAllActivities.SelectedIndex;
            lbxSelectedActivities.Items.Add(selectedItemText);
            if (activities != null)
            {
                activities.RemoveAt(SelectedIndex);
            }
            DataBinding();
        }

        private void DataBinding()
        {
            //throw new NotImplementedException();
            lbxAllActivities.ItemsSource = null;
            lbxAllActivities.ItemsSource = activities;
        }

        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            selectedItemText = lbxSelectedActivities.SelectedItem.ToString();
            SelectedIndex = lbxSelectedActivities.SelectedIndex;
     
            lbxSelectedActivities.Items.RemoveAt(lbxSelectedActivities.Items.IndexOf(lbxSelectedActivities.SelectedItem));

            
        }

        private void Rb_Checked(object sender, RoutedEventArgs e)
        {
            //reset the filter
            filteredActivities.Clear();

            //if all checked, display all
            if (rbAll.IsChecked == true)
            {
                lbxAllActivities.ItemsSource = activities;
            }


            //else if 1 checked display 1
            else if (rbLand.IsChecked == true)
            {
                foreach (Activity activity in activities)
                {
                    if (activity.TypeOfActivity == Activity.ActivityType.Land)
                    {
                        //add to filtered collection
                        filteredActivities.Add(activity);
                    }
                }
                lbxAllActivities.ItemsSource = filteredActivities;
            }
            //else if 2 checked display 2
            else if (rbWater.IsChecked == true)
            {
                foreach (Activity activity in activities)
                {
                    if (activity.TypeOfActivity == Activity.ActivityType.Water)
                    {
                        //add to filtered collection
                        filteredActivities.Add(activity);
                    }
                }
                lbxAllActivities.ItemsSource = filteredActivities;
            }
            //else if 3 checked display 3
            else if (rbAir.IsChecked == true)
            {
                foreach (Activity activity in activities)
                {
                    if (activity.TypeOfActivity == Activity.ActivityType.Air)
                    {
                        //add to filtered collection
                        filteredActivities.Add(activity);
                    }
                }
                lbxAllActivities.ItemsSource = filteredActivities;
            }
        }
    }
}
