﻿using System;
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
using UI.ServiceReference1;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LandServiceClient proxy;
        public MainWindow()
        {
            InitializeComponent();            
            proxy = new LandServiceClient();
            PIRadioBtn.IsChecked = true;
        }

        private void GridAddComBoxLandCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GridAddComBoxPurpose.Items.Clear();

            LandCategoryDTO selectedItem = (LandCategoryDTO)GridAddComBoxLandCategory.SelectedItem;

            if (selectedItem == null) return;  

            foreach (var item in proxy.GetPurposes(selectedItem.Name))
            {
                GridAddComBoxPurpose.Items.Add(item);
            }
        }

        private void GridAddComBoxPurpose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PurposeDTO selectedItem = (PurposeDTO)GridAddComBoxPurpose.SelectedItem;

            if (selectedItem == null)
                GridAddExploitationType.Text = "";
            else
                GridAddExploitationType.Text = selectedItem.Name;
        }

        private void AddLandLotBtn_Click(object sender, RoutedEventArgs e)
        {
            GridAdd.Visibility = Visibility.Visible;

            GridAddComBoxSoils.DisplayMemberPath = "FullName";
            GridAddComBoxPurpose.DisplayMemberPath = "FullName";
            GridAddComBoxLandCategory.DisplayMemberPath = "Name";
            GridAddComBoxOwnershipType.DisplayMemberPath = "Name";

            foreach (var item in proxy.GetLandCategories())
            {
                GridAddComBoxLandCategory.Items.Add(item);
            }

            foreach (var item in proxy.GetOwnershipTypes())
            {
                GridAddComBoxOwnershipType.Items.Add(item);
            }
            foreach (var item in proxy.GetSoils())
            {
                GridAddComBoxSoils.Items.Add(item);
            }
        }

        private void JIRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            GridAddPIName.Visibility = Visibility.Collapsed;
            GridAddPISurname.Visibility = Visibility.Collapsed;
            GridAddPIMiddleName.Visibility = Visibility.Collapsed;
            GridAddPIBirdDate.Visibility = Visibility.Collapsed;
            GridAddJIName.Visibility = Visibility.Visible;
            GridAddJIEDRPOUcode.Visibility = Visibility.Visible;
        }

        private void PIRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            GridAddPIName.Visibility = Visibility.Visible;
            GridAddPISurname.Visibility = Visibility.Visible;
            GridAddPIMiddleName.Visibility = Visibility.Visible;
            GridAddPIBirdDate.Visibility = Visibility.Visible;
            GridAddJIName.Visibility = Visibility.Collapsed;
            GridAddJIEDRPOUcode.Visibility = Visibility.Collapsed;
        }

        private void GridAddBtnAddLandLot_Click(object sender, RoutedEventArgs e)
        {

            LandCategoryDTO selectedItemLandCategory = (LandCategoryDTO)GridAddComBoxLandCategory.SelectedItem;
            OwnershipTypeDTO selectedItemOwnershipType = (OwnershipTypeDTO)GridAddComBoxOwnershipType.SelectedItem;
            PurposeDTO selectedItemPurpose = (PurposeDTO)GridAddComBoxPurpose.SelectedItem;
            SoilDTO selectedItemSoil = (SoilDTO)GridAddComBoxSoils.SelectedItem;
                                                         
            LandLotDTO landLotDTO = new LandLotDTO()
            {
                CadastralNumber = GridAddCadastralNumber.Text,
                Area = double.Parse(GridAddArea.Text),
                LandCategoryId = selectedItemLandCategory.Id,
                OwnershipTypeId = selectedItemOwnershipType.Id,
                PurposeId = selectedItemPurpose.Id,
                SoilId = selectedItemSoil.Id
            };

            //+LandLotDTO landLotDTO,
            //+ExploitationTypeDTO exploitationTypeDTO,            
            //+LocationDTO locationDTO,
            //+MonetaryValuationDTO monetaryValuationDTO,           

            //+StateRegistrationInfoDTO stateRegistrationInfoDTO,
            //ICollection<PhysicalIndividualDTO> physicalIndividualDTOs,
            //JuridicalIndividualDTO juridicalIndividualDTO

            ExploitationTypeDTO exploitationTypeDTO = new ExploitationTypeDTO()
            {
                Name = GridAddExploitationType.Text
            };

            LocationDTO locationDTO = new LocationDTO()
            {
                Region = GridAddLocationRegion.Text,
                District = GridAddLocationDistrict.Text,
                Settlement = GridAddLocationSettlement.Text,
                Street = GridAddLocationStreet.Text
            };

            MonetaryValuationDTO monetaryValuationDTO = new MonetaryValuationDTO()
            {
                Kf = double.Parse(GridAddMonetaryValuationKf.Text),
                Km = double.Parse(GridAddMonetaryValuationKm.Text),
                Value = decimal.Parse(GridAddMonetaryValuationValue.Text)
            };

            StateRegistrationInfoDTO stateRegistrationInfoDTO = new StateRegistrationInfoDTO()
            {
                RegistrationAgency = GridAddRegistrationInfoAgency.Text,
                TechnicalDocumentation = GridAddRegistrationInfoTechnicalDocumentation.Text,
                DateTime = GridAddRegistrationInfoDate.SelectedDate.Value
            };

            if(PIRadioBtn.IsChecked == true)
            {
                PhysicalIndividualDTO physicalIndividualDTO = new PhysicalIndividualDTO()
                {   
                    Id=-1,
                    Name = GridAddPIName.Text,
                    Surname = GridAddPISurname.Text,
                    MiddleName = GridAddPIMiddleName.Text,
                    DateOfBirth = GridAddPIBirdDate.SelectedDate.Value
                };

                proxy.AddLandLot
                (
                    landLotDTO,
                    exploitationTypeDTO,
                    locationDTO,
                    monetaryValuationDTO,
                    stateRegistrationInfoDTO,
                    new PhysicalIndividualDTO[] {physicalIndividualDTO},
                    null
                );
            }
            else if (JIRadioBtn.IsChecked == true)
            {
                JuridicalIndividualDTO juridicalIndividualDTO = new JuridicalIndividualDTO()
                {
                    EDRPOUcode = GridAddJIEDRPOUcode.Text,
                    Name = GridAddJIName.Text
                  
                };

                proxy.AddLandLot
              (
                  landLotDTO,
                  exploitationTypeDTO,
                  locationDTO,
                  monetaryValuationDTO,
                  stateRegistrationInfoDTO,
                  null,
                  juridicalIndividualDTO
              );
            }
                
        }
    }
}
