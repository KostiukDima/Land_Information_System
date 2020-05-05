using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBInitializer : CreateDatabaseIfNotExists<LandSystemDBModel>
    {
        protected override void Seed(LandSystemDBModel context)
        {
            base.Seed(context);


            // Add Purposes
            {
                context.Purposes.Add(new Purpose() { Code = "01.01", Name = "Для ведення товарного сільськогосподарського виробництва" });
                context.Purposes.Add(new Purpose() { Code = "01.02", Name = "Для ведення фермерського господарства" });
                context.Purposes.Add(new Purpose() { Code = "01.03", Name = "Для ведення особистого селянського господарства" });
                context.Purposes.Add(new Purpose() { Code = "01.04", Name = "Для ведення підсобного сільського господарства" });
                context.Purposes.Add(new Purpose() { Code = "01.05", Name = "Для індивідуального садівництва" });
                context.Purposes.Add(new Purpose() { Code = "01.06", Name = "Для колективного садівництва" });
                context.Purposes.Add(new Purpose() { Code = "01.07", Name = "Для городництва" });
                context.Purposes.Add(new Purpose() { Code = "01.08", Name = "Для сінокосіння і випасання худоби" });
                context.Purposes.Add(new Purpose() { Code = "01.09", Name = "Для дослідних і навчальних цілей" });
                context.Purposes.Add(new Purpose() { Code = "01.10", Name = "Для пропаганди передового досвіду ведення сільського господарства" });
                context.Purposes.Add(new Purpose() { Code = "01.11", Name = "Для надання послуг у сільському господарстві" });
                context.Purposes.Add(new Purpose() { Code = "01.12", Name = "Для розміщення інфраструктури оптових ринків сільськогосподарської продукції" });
                context.Purposes.Add(new Purpose() { Code = "01.13", Name = "Для іншого сільськогосподарського призначення" });
                context.Purposes.Add(new Purpose() { Code = "01.14", Name = "Для цілей підрозділів 01.01 - 01.13 та для збереження та використання земель природно - заповідного фонду" });
                context.Purposes.Add(new Purpose() { Code = "02.01", Name = "Для будівництва і обслуговування житлового будинку, господарських будівель і споруд(присадибна ділянка)" });
                context.Purposes.Add(new Purpose() { Code = "02.02", Name = "Для колективного житлового будівництва" });
                context.Purposes.Add(new Purpose() { Code = "02.03", Name = "Для будівництва і обслуговування багатоквартирного житлового будинку" });
                context.Purposes.Add(new Purpose() { Code = "02.04", Name = "Для будівництва і обслуговування будівель тимчасового проживання" });
                context.Purposes.Add(new Purpose() { Code = "02.05", Name = "Для будівництва індивідуальних гаражів" });
                context.Purposes.Add(new Purpose() { Code = "02.06", Name = "Для колективного гаражного будівництва" });
                context.Purposes.Add(new Purpose() { Code = "02.07", Name = "Для іншої житлової забудови" });
                context.Purposes.Add(new Purpose() { Code = "02.08", Name = "Для цілей підрозділів 02.01 - 02.07 та для збереження та використання земель природно - заповідного фонду" });
                context.Purposes.Add(new Purpose() { Code = "03.01", Name = "Для будівництва та обслуговування будівель органів державної влади та місцевого самоврядування" });
                context.Purposes.Add(new Purpose() { Code = "03.02", Name = "Для будівництва та обслуговування будівель закладів освіти" });
                context.Purposes.Add(new Purpose() { Code = "03.03", Name = "Для будівництва та обслуговування будівель закладів охорони здоров'я та соціальної допомоги" });
                context.Purposes.Add(new Purpose() { Code = "03.04", Name = "Для будівництва та обслуговування будівель громадських та релігійних організацій" });
                context.Purposes.Add(new Purpose() { Code = "03.05", Name = "Для будівництва та обслуговування будівель закладів культурно - просвітницького обслуговування" });
                context.Purposes.Add(new Purpose() { Code = "03.06", Name = "Для будівництва та обслуговування будівель екстериторіальних організацій та органів" });
                context.Purposes.Add(new Purpose() { Code = "03.07", Name = "Для будівництва та обслуговування будівель торгівлі" });
                context.Purposes.Add(new Purpose() { Code = "03.08", Name = "Для будівництва та обслуговування об'єктів туристичної інфраструктури та закладів громадського харчування" });
                context.Purposes.Add(new Purpose() { Code = "03.09", Name = "Для будівництва та обслуговування будівель кредитно-фінансових установ" });
                context.Purposes.Add(new Purpose() { Code = "03.10", Name = "Для будівництва та обслуговування будівель ринкової інфраструктури" });
                context.Purposes.Add(new Purpose() { Code = "03.11", Name = "Для будівництва та обслуговування будівель і споруд закладів науки" });
                context.Purposes.Add(new Purpose() { Code = "03.12", Name = "Для будівництва та обслуговування будівель закладів комунального обслуговування" });
                context.Purposes.Add(new Purpose() { Code = "03.13", Name = "Для будівництва та обслуговування будівель закладів побутового обслуговування" });
                context.Purposes.Add(new Purpose() { Code = "03.14", Name = "Для розміщення та постійної діяльності органів МНС" });
                context.Purposes.Add(new Purpose() { Code = "03.15", Name = "Для будівництва та обслуговування інших будівель громадської забудови" });
                context.Purposes.Add(new Purpose() { Code = "03.16", Name = "Для цілей підрозділів 03.01 - 03.15 та для збереження та використання земель природно - заповідного фонду" });
                context.Purposes.Add(new Purpose() { Code = "04.01", Name = "Для збереження та використання біосферних заповідників" });
                context.Purposes.Add(new Purpose() { Code = "04.02", Name = "Для збереження та використання природних заповідників" });
                context.Purposes.Add(new Purpose() { Code = "04.03", Name = "Для збереження та використання національних природних парків" });
                context.Purposes.Add(new Purpose() { Code = "04.04", Name = "Для збереження та використання ботанічних садів" });
                context.Purposes.Add(new Purpose() { Code = "04.05", Name = "Для збереження та використання зоологічних парків" });
                context.Purposes.Add(new Purpose() { Code = "04.06", Name = "Для збереження та використання дендрологічних парків" });
                context.Purposes.Add(new Purpose() { Code = "04.07", Name = "Для збереження та використання парків - пам'яток садово-паркового мистецтва" });
                context.Purposes.Add(new Purpose() { Code = "04.08", Name = "Для збереження та використання заказників" });
                context.Purposes.Add(new Purpose() { Code = "04.09", Name = "Для збереження та використання заповідних урочищ" });
                context.Purposes.Add(new Purpose() { Code = "04.10", Name = "Для збереження та використання пам'яток природи" });
                context.Purposes.Add(new Purpose() { Code = "04.11", Name = "Для збереження та використання регіональних ландшафтних парків" });
                context.Purposes.Add(new Purpose() { Code = "05.00", Name = "Землі іншого природоохоронного призначення(земельні ділянки, в межах яких є природні об'єкти, що мають особливу наукову цінність, та які надаються для збереження і використання цих об'єктів, проведення наукових досліджень, освітньої та виховної роботи)" });
                context.Purposes.Add(new Purpose() { Code = "06.01", Name = "Для будівництва і обслуговування санаторно - оздоровчих закладів" });
                context.Purposes.Add(new Purpose() { Code = "06.02", Name = "Для розробки родовищ природних лікувальних ресурсів" });
                context.Purposes.Add(new Purpose() { Code = "06.03", Name = "Для інших оздоровчих цілей" });
                context.Purposes.Add(new Purpose() { Code = "06.04", Name = "Для цілей підрозділів 06.01 - 06.03 та для збереження та використання земель природно - заповідного фонду" });
                context.Purposes.Add(new Purpose() { Code = "07.01", Name = "Для будівництва та обслуговування об'єктів рекреаційного призначення" });
                context.Purposes.Add(new Purpose() { Code = "07.02", Name = "Для будівництва та обслуговування об'єктів фізичної культури і спорту" });
                context.Purposes.Add(new Purpose() { Code = "07.03", Name = "Для індивідуального дачного будівництва" });
                context.Purposes.Add(new Purpose() { Code = "07.04", Name = "Для колективного дачного будівництва" });
                context.Purposes.Add(new Purpose() { Code = "07.05", Name = "Для цілей підрозділів 07.01 - 07.04 та для збереження та використання земель природно - заповідного фонду" });
                context.Purposes.Add(new Purpose() { Code = "08.01", Name = "Для забезпечення охорони об'єктів культурної спадщини" });
                context.Purposes.Add(new Purpose() { Code = "08.02", Name = "Для розміщення та обслуговування музейних закладів" });
                context.Purposes.Add(new Purpose() { Code = "08.03", Name = "Для іншого історико - культурного призначення" });
                context.Purposes.Add(new Purpose() { Code = "08.04", Name = "Для цілей підрозділів 08.01 - 08.03 та для збереження та використання земель природно - заповідного фонду" });
                context.Purposes.Add(new Purpose() { Code = "09.01", Name = "Для ведення лісового господарства і пов'язаних з ним послуг" });
                context.Purposes.Add(new Purpose() { Code = "09.02", Name = "Для іншого лісогосподарського призначення" });
                context.Purposes.Add(new Purpose() { Code = "09.03", Name = "Для цілей підрозділів 09.01 - 09.02 та для збереження та використання земель природно - заповідного фонду" });
                context.Purposes.Add(new Purpose() { Code = "10.01", Name = "Для експлуатації та догляду за водними об'єктами" });
                context.Purposes.Add(new Purpose() { Code = "10.02", Name = "Для облаштування та догляду за прибережними захисними смугами" });
                context.Purposes.Add(new Purpose() { Code = "10.03", Name = "Для експлуатації та догляду за смугами відведення" });
                context.Purposes.Add(new Purpose() { Code = "10.04", Name = "Для експлуатації та догляду за гідротехнічними, іншими водогосподарськими спорудами і каналами" });
                context.Purposes.Add(new Purpose() { Code = "10.05", Name = "Для догляду за береговими смугами водних шляхів" });
                context.Purposes.Add(new Purpose() { Code = "10.06", Name = "Для сінокосіння" });
                context.Purposes.Add(new Purpose() { Code = "10.07", Name = "Для рибогосподарських потреб" });
                context.Purposes.Add(new Purpose() { Code = "10.08", Name = "Для культурно-оздоровчих потреб, рекреаційних, спортивних і туристичних цілей" });
                context.Purposes.Add(new Purpose() { Code = "10.09", Name = "Для проведення науково - дослідних робіт" });
                context.Purposes.Add(new Purpose() { Code = "10.10", Name = "Для будівництва та експлуатації гідротехнічних, гідрометричних та лінійних споруд" });
                context.Purposes.Add(new Purpose() { Code = "10.11", Name = "Для будівництва та експлуатації санаторіїв та інших лікувально-оздоровчих закладів у межах прибережних захисних смуг морів, морських заток і лиманів" });
                context.Purposes.Add(new Purpose() { Code = "10.12", Name = "Для цілей підрозділів 10.01 - 10.11 та для збереження та використання земель природно - заповідного фонду" });
                context.Purposes.Add(new Purpose() { Code = "11.01", Name = "Для розміщення та експлуатації основних, підсобних і допоміжних будівель та споруд підприємствами, що пов'язані з користуванням надрами" });
                context.Purposes.Add(new Purpose() { Code = "11.02", Name = "Для розміщення та експлуатації основних, підсобних і допоміжних будівель та споруд підприємств переробної, машинобудівної та іншої промисловості" });
                context.Purposes.Add(new Purpose() { Code = "11.03", Name = "Для розміщення та експлуатації основних, підсобних і допоміжних будівель та споруд будівельних організацій та підприємств" });
                context.Purposes.Add(new Purpose() { Code = "11.04", Name = "Для розміщення та експлуатації основних, підсобних і допоміжних будівель та споруд технічної інфраструктури(виробництва та розподілення газу, постачання пари та гарячої води, збирання, очищення та розподілення води)" });
                context.Purposes.Add(new Purpose() { Code = "11.05", Name = "Для цілей підрозділів 11.01 - 11.04 та для збереження та використання земель природно - заповідного фонду" });
                context.Purposes.Add(new Purpose() { Code = "12.01", Name = "Для розміщення та експлуатації будівель і споруд залізничного транспорту" });
                context.Purposes.Add(new Purpose() { Code = "12.02", Name = "Для розміщення та експлуатації будівель і споруд морського транспорту" });
                context.Purposes.Add(new Purpose() { Code = "12.03", Name = "Для розміщення та експлуатації будівель і споруд річкового транспорту" });
                context.Purposes.Add(new Purpose() { Code = "12.04", Name = "Для розміщення та експлуатації будівель і споруд автомобільного транспорту та дорожнього господарства" });
                context.Purposes.Add(new Purpose() { Code = "12.05", Name = "Для розміщення та експлуатації будівель і споруд авіаційного транспорту" });
                context.Purposes.Add(new Purpose() { Code = "12.06", Name = "Для розміщення та експлуатації об'єктів трубопровідного транспорту" });
                context.Purposes.Add(new Purpose() { Code = "12.07", Name = "Для розміщення та експлуатації будівель і споруд міського електротранспорту" });
                context.Purposes.Add(new Purpose() { Code = "12.08", Name = "Для розміщення та експлуатації будівель і споруд додаткових транспортних послуг та допоміжних операцій" });
                context.Purposes.Add(new Purpose() { Code = "12.09", Name = "Для розміщення та експлуатації будівель і споруд іншого наземного транспорту" });
                context.Purposes.Add(new Purpose() { Code = "12.10", Name = "Для цілей підрозділів 12.01 - 12.09 та для збереження та використання земель природно - заповідного фонду" });
                context.Purposes.Add(new Purpose() { Code = "13.01", Name = "Для розміщення та експлуатації об'єктів і споруд телекомунікацій" });
                context.Purposes.Add(new Purpose() { Code = "13.02", Name = "Для розміщення та експлуатації будівель та споруд об'єктів поштового зв'язку" });
                context.Purposes.Add(new Purpose() { Code = "13.03", Name = "Для розміщення та експлуатації інших технічних засобів зв'язку" });
                context.Purposes.Add(new Purpose() { Code = "13.04", Name = "Для цілей підрозділів 13.01 - 13.03 та для збереження та використання земель природно - заповідного фонду" });
                context.Purposes.Add(new Purpose() { Code = "14.01", Name = "Для розміщення, будівництва, експлуатації та обслуговування будівель і споруд об'єктів енергогенеруючих підприємств, установ і організацій" });
                context.Purposes.Add(new Purpose() { Code = "14.02", Name = "Для розміщення, будівництва, експлуатації та обслуговування будівель і споруд об'єктів передачі електричної та теплової енергії" });
                context.Purposes.Add(new Purpose() { Code = "14.03", Name = "Для цілей підрозділів 14.01 - 14.02 та для збереження та використання земель природно - заповідного фонду" });
                context.Purposes.Add(new Purpose() { Code = "15.01", Name = "Для розміщення та постійної діяльності Збройних Сил України" });
                context.Purposes.Add(new Purpose() { Code = "15.02", Name = "Для розміщення та постійної діяльності внутрішніх військ МВС" });
                context.Purposes.Add(new Purpose() { Code = "15.03", Name = "Для розміщення та постійної діяльності Державної прикордонної служби України" });
                context.Purposes.Add(new Purpose() { Code = "15.04", Name = "Для розміщення та постійної діяльності Служби безпеки України" });
                context.Purposes.Add(new Purpose() { Code = "15.05", Name = "Для розміщення та постійної діяльності Державної спеціальної служби транспорту" });
                context.Purposes.Add(new Purpose() { Code = "15.06", Name = "Для розміщення та постійної діяльності Служби зовнішньої розвідки України" });
                context.Purposes.Add(new Purpose() { Code = "15.07", Name = "Для розміщення та постійної діяльності інших, створених відповідно до законів України, військових формувань" });
                context.Purposes.Add(new Purpose() { Code = "15.08", Name = "Для цілей підрозділів 15.01 - 15.07 та для збереження та використання земель природно - заповідного фонду" });
                context.Purposes.Add(new Purpose() { Code = "16.00", Name = "Землі запасу(земельні ділянки кожної категорії земель, які не надані у власність або користування громадянам чи юридичним особам)" });
                context.Purposes.Add(new Purpose() { Code = "17.00", Name = "Землі резервного фонду(землі, створені органами виконавчої влади або органами місцевого самоврядування у процесі приватизації сільськогосподарських угідь, які були у постійному користуванні відповідних підприємств, установ та організацій)" });
                context.Purposes.Add(new Purpose() { Code = "18.00", Name = "Землі загального користування(землі будь - якої категорії, які використовуються як майдани, вулиці, проїзди, шляхи, громадські пасовища, сіножаті, набережні, пляжі, парки, зеленізони, сквери, бульвари, водні об'єкти загального користування, а також інші землі, якщо рішенням відповідного органу державної влади чи місцевого самоврядування їх віднесено до земель загального користування)" });
                context.Purposes.Add(new Purpose() { Code = "19.00", Name = "Для цілей підрозділів 16.00 - 18.00 та для збереження та використання земель природно - заповідного фонду" });
            }

            // Add LandCategories
            {
                context.LandCategories.Add(new LandCategory() { Name = "Землі сільськогосподарського призначення" });
                context.LandCategories.Add(new LandCategory() { Name = "Землі житлової та громадської забудови" });
                context.LandCategories.Add(new LandCategory() { Name = "Землі природно-заповідного та іншого природоохоронного призначення" });
                context.LandCategories.Add(new LandCategory() { Name = "Землі оздоровчого призначення" });
                context.LandCategories.Add(new LandCategory() { Name = "Землі рекреаційного призначення" });
                context.LandCategories.Add(new LandCategory() { Name = "Землі історико-культурного призначення" });
                context.LandCategories.Add(new LandCategory() { Name = "Землі лісогосподарського призначення" });
                context.LandCategories.Add(new LandCategory() { Name = "Землі водного фонду" });
                context.LandCategories.Add(new LandCategory() { Name = "Землі промисловості, транспорту, зв'язку, енергетики, оборони та іншого призначення" });
            }
        }
    }
}
