using System;
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
        int SelectedLandLotDTOId;
        public MainWindow()
        {
            InitializeComponent();
            proxy = new LandServiceClient();
            PIRadioBtn.IsChecked = true;
            GridFindRadioBtnCadasNum.IsChecked = true;
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
            GridFind.Visibility = Visibility.Collapsed;
            GridInfo.Visibility = Visibility.Collapsed;


            GridAddComBoxSoils.DisplayMemberPath = "FullName";
            GridAddComBoxPurpose.DisplayMemberPath = "FullName";
            GridAddComBoxLandCategory.DisplayMemberPath = "Name";
            GridAddComBoxOwnershipType.DisplayMemberPath = "Name";

            if (GridAddComBoxLandCategory.Items.Count == 0)
                foreach (var item in proxy.GetLandCategories())
                {
                    GridAddComBoxLandCategory.Items.Add(item);
                }

            if (GridAddComBoxOwnershipType.Items.Count == 0)
                foreach (var item in proxy.GetOwnershipTypes())
                {
                    GridAddComBoxOwnershipType.Items.Add(item);
                }

            if (GridAddComBoxSoils.Items.Count == 0)
                foreach (var item in proxy.GetSoils())
                {
                    GridAddComBoxSoils.Items.Add(item);
                }

            GridAddCadastralNumber.Text = "";
            GridAddArea.Text = "";
            GridAddComBoxLandCategory.SelectedItem = null;
            GridAddComBoxPurpose.SelectedItem = null;
            GridAddExploitationType.Text =null;
            GridAddComBoxSoils.SelectedItem = null;

            
            GridAddLocationRegion.Text = "";
            GridAddLocationDistrict.Text = "";
            GridAddLocationSettlement.Text = "";
            GridAddLocationStreet.Text = "";

            GridAddMonetaryValuationKm.Text = "";
            GridAddMonetaryValuationKf.Text = "";
            GridAddMonetaryValuationValue.Text = "";

            GridAddRegistrationInfoAgency.Text = "";
            GridAddRegistrationInfoTechnicalDocumentation.Text = "";
            GridAddRegistrationInfoDate.Text = "";

            GridAddPIName.Text = "";
            GridAddPISurname.Text = "";
            GridAddPIMiddleName.Text = "";
            GridAddPIBirdDate.SelectedDate = null;


            GridAddJIEDRPOUcode.Text = "";
            GridAddJIName.Text = "";




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

        private void GridInfoJIRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            GridAddPIName.Visibility = Visibility.Collapsed;
            GridAddPISurname.Visibility = Visibility.Collapsed;
            GridAddPIMiddleName.Visibility = Visibility.Collapsed;
            GridAddPIBirdDate.Visibility = Visibility.Collapsed;
            GridAddJIName.Visibility = Visibility.Visible;
            GridAddJIEDRPOUcode.Visibility = Visibility.Visible;
        }

        private void GridInfoPIRadioBtn_Checked(object sender, RoutedEventArgs e)
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

            if (PIRadioBtn.IsChecked == true)
            {
                PhysicalIndividualDTO physicalIndividualDTO = new PhysicalIndividualDTO()
                {
                    Id = -1,
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
                    new PhysicalIndividualDTO[] { physicalIndividualDTO },
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

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            LandLotDTO[] landLotDTOs = null;
            if (GridFindRadioBtnCadasNum.IsChecked == true)
            { }
            else if (GridFindRadioBtnOwner.IsChecked == true)
            { }
            else if (GridFindRadioBtnLandCatrgory.IsChecked == true)
                landLotDTOs = proxy.GetLandLotsbyLandCategory(TextFind.Text);
            else if (GridFindRadioBtnPurpose.IsChecked == true)
            { }
            else if (GridFindRadioBtnSoil.IsChecked == true)
            { }
            else if (GridFindRadioBtnOwnershipType.IsChecked == true)
            { }

            ListBoxFindLand.Items.Clear();

            if (landLotDTOs == null)
                ListBoxFindLand.Items.Add(new Label() { Content = "Ділянок не знайдено", HorizontalAlignment = HorizontalAlignment.Center });
            else
                foreach (var item in landLotDTOs)
                {
                    StackPanel sp = new StackPanel()
                    {
                        Orientation = Orientation.Horizontal
                    };

                    sp.Children.Add(new Label() { Content = item.CadastralNumber, });
                    sp.Children.Add(new Label() { Content = proxy.GetLandCategoryById(item.Id).Name });

                    LocationDTO location = proxy.GetLocationById(item.Id);
                    sp.Children.Add(new Label() { Content = location.District + " " + location.Settlement });

                    //MessageBox.Show(item.Id.ToString());
                    //PhysicalIndividualDTO[] physicalIndividuals = proxy.GetOwnerByIdP(item.Id);
                    //JuridicalIndividualDTO juridicalIndividual = proxy.GetOwnerByIdJ(item.Id);

                    //if(physicalIndividuals!=null)
                    //{
                    //    foreach (var i in physicalIndividuals)
                    //    {
                    //        sp.Children.Add(new Label() { Content = i.Name+" "+i.Surname });

                    //    }
                    //}
                    //else if(juridicalIndividual!=null)
                    //{
                    //    sp.Children.Add(new Label() { Content = juridicalIndividual.Name });
                    //}



                    sp.Tag = item;

                    ListBoxFindLand.Items.Add(sp);
                }



        }

        private void GridFindRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            //if(GridFindRadioBtnCadasNum.IsChecked == true)              
            //else if(GridFindRadioBtnOwner.IsChecked == true)
            //else if(GridFindRadioBtnLandCatrgory.IsChecked == true)
            //else if (GridFindRadioBtnPurpose.IsChecked == true)
            //else if(GridFindRadioBtnSoil.IsChecked == true)
            //else if(GridFindRadioBtnOwnershipType.IsChecked == true)      
        }

        private void FindLandLotBtn_Click(object sender, RoutedEventArgs e)
        {
            GridAdd.Visibility = Visibility.Collapsed;
            GridFind.Visibility = Visibility.Visible;
            GridInfo.Visibility = Visibility.Collapsed;

            ListBoxFindLand.Items.Clear();
            TextFind.Text = "";
        }

        

        private void ListBoxFindLand_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListBoxFindLand.SelectedItem == null) return;

            LandLotDTO landLotDTO = (LandLotDTO)((StackPanel)ListBoxFindLand.SelectedItem).Tag;
            SelectedLandLotDTOId = landLotDTO.Id;

            GridFind.Visibility = Visibility.Collapsed;

            GridInfoCadastralNumber.Text = landLotDTO.CadastralNumber;
            GridInfoArea.Text = landLotDTO.Area.ToString()+"га";
            GridInfoLandCategory.Text = proxy.GetLandCategoryById(landLotDTO.LandCategoryId).Name;
            GridInfoPurpose.Text = proxy.GetPurposeById(landLotDTO.PurposeId).FullName;
            GridInfoExploitationType.Text = proxy.GetExploitationTypeById(landLotDTO.ExploitationTypeId).Name;
            if (landLotDTO.SoilId != null)
                GridInfoSoils.Text = proxy.GetSoilById(landLotDTO.SoilId.Value).FullName;

            LocationDTO locationDTO = proxy.GetLocationById(landLotDTO.LocationId);
            GridInfoLocationRegion.Text = locationDTO.Region;
            GridInfoLocationDistrict.Text = locationDTO.District;
            GridInfoLocationSettlement.Text = locationDTO.Settlement;
            GridInfoLocationStreet.Text = locationDTO.Street;


            //GridInfoListBox
            MonetaryValuationDTO monetaryValuationDTO = proxy.GetMonetaryValuationById(landLotDTO.MonetaryValuationId);

            GridInfoMonetaryValuationKm.Text = monetaryValuationDTO.Km.ToString();
            GridInfoMonetaryValuationKf.Text = monetaryValuationDTO.Kf.ToString();
            GridInfoMonetaryValuationValue.Text = monetaryValuationDTO.Value.ToString();

            StateRegistrationInfoDTO infoDTO = proxy.GetStateRegistrationInfoById(landLotDTO.StateRegistrationInfoId);

            GridInfoRegistrationInfoAgency.Text = infoDTO.RegistrationAgency;
            GridInfoRegistrationInfoTechnicalDocumentation.Text = infoDTO.TechnicalDocumentation;
            GridInfoRegistrationInfoDate.Text = infoDTO.DateTime.ToShortTimeString();

            GridInfo.Visibility = Visibility.Visible;
            

        }

        private void GridInfoBtnClose_Click(object sender, RoutedEventArgs e)
        {
            GridInfo.Visibility = Visibility.Collapsed;
            GridAdd.Visibility = Visibility.Collapsed;
            GridFind.Visibility = Visibility.Visible;
        }

        private void GridInfoBtnEdit_Click(object sender, RoutedEventArgs e)
        {
            GridInfo.Visibility = Visibility.Collapsed;
            GridAdd.Visibility = Visibility.Visible;
            GridFind.Visibility = Visibility.Collapsed;

            LandLotDTO landLotDTO = (LandLotDTO)((StackPanel)ListBoxFindLand.SelectedItem).Tag;
                     

            GridAddCadastralNumber.Text = landLotDTO.CadastralNumber;
            GridAddArea.Text = landLotDTO.Area.ToString();
            GridAddComBoxLandCategory.SelectedItem = proxy.GetLandCategoryById(landLotDTO.LandCategoryId);
            GridAddComBoxPurpose.SelectedItem = proxy.GetPurposeById(landLotDTO.PurposeId);
            GridAddExploitationType.Text = proxy.GetExploitationTypeById(landLotDTO.ExploitationTypeId).Name;
            if (landLotDTO.SoilId != null)
                GridAddComBoxSoils.SelectedItem = proxy.GetSoilById(landLotDTO.SoilId.Value);

            LocationDTO locationDTO = proxy.GetLocationById(landLotDTO.LocationId);
            GridAddLocationRegion.Text = locationDTO.Region;
            GridAddLocationDistrict.Text = locationDTO.District;
            GridAddLocationSettlement.Text = locationDTO.Settlement;
            GridAddLocationStreet.Text = locationDTO.Street;


            //GridInfoListBox
            MonetaryValuationDTO monetaryValuationDTO = proxy.GetMonetaryValuationById(landLotDTO.MonetaryValuationId);

            GridAddMonetaryValuationKm.Text = monetaryValuationDTO.Km.ToString();
            GridAddMonetaryValuationKf.Text = monetaryValuationDTO.Kf.ToString();
            GridAddMonetaryValuationValue.Text = monetaryValuationDTO.Value.ToString();
                     
            StateRegistrationInfoDTO infoDTO = proxy.GetStateRegistrationInfoById(landLotDTO.StateRegistrationInfoId);

            GridAddRegistrationInfoAgency.Text = infoDTO.RegistrationAgency;
            GridAddRegistrationInfoTechnicalDocumentation.Text = infoDTO.TechnicalDocumentation;
            GridAddRegistrationInfoDate.Text = infoDTO.DateTime.ToShortTimeString();
            
            




            //
            //
            //
            //
            //
            //
            //GridAddLocationRegion
            //GridAddLocationDistrict
            //GridAddLocationSettlement
            //GridAddLocationStreet
            //GridAddComBoxOwnershipType
            //GridAddMonetaryValuationKm
            //GridAddMonetaryValuationKf
            //GridAddMonetaryValuationValue
            //GridAddRegistrationInfoAgency
            //GridAddRegistrationInfoDate
            //GridAddRegistrationInfoTechnicalDocumentation
        }
    }
}
