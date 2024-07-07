using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RESTAPIProject.Migrations
{
    /// <inheritdoc />
    public partial class SeedVillaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { -99, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(640), "CZOWMFVDKPMXB", "", "XNREPI Villa", 94, 567.80999999999995, 7586, null },
                    { -98, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(626), "DUUHMDVMSPFWOQPW", "", "IKKY Villa", 58, 240.28999999999999, 45431, null },
                    { -97, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(611), "GL A JEMSFBKLF", "", "SFQCCG Villa", 42, 524.73000000000002, 7649, null },
                    { -96, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(596), "IXHUKGFARTDMSKMLM", "", "OMF Villa", 85, 634.83000000000004, 37136, null },
                    { -95, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(581), "DKITLZMMQNC", "", "ZUQ Villa", 32, 313.58999999999997, 15497, null },
                    { -94, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(569), "KETAKQVWH YBAJY", "", "RPIZC Villa", 35, 179.19999999999999, 5972, null },
                    { -93, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(555), "BALFFBECTDFJ ", "", "LTI Villa", 2, 848.74000000000001, 20471, null },
                    { -92, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(542), "FHEFEQKSJQQCFFUHRBZ", "", "QJHD Villa", 35, 474.07999999999998, 45369, null },
                    { -91, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(526), "XKHUPMUQNUYMP", "", "GAI Villa", 59, 680.46000000000004, 18380, null },
                    { -90, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(513), "DCEDPHGCQPFXKJTXS", "", "HCZCPUY Villa", 35, 520.39999999999998, 8183, null },
                    { -89, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(497), "PEFXRYQIPFA", "", "BQKCOBA Villa", 22, 284.62, 24398, null },
                    { -88, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(460), "UKRNWVYJCCZV", "", "LBCNBT Villa", 45, 463.75, 39884, null },
                    { -87, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(446), "TXDYWFBPGBKC ", "", "JFOXZI Villa", 62, 768.09000000000003, 5640, null },
                    { -86, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(431), "WB BQTCRUPRQLHAHV", "", "ZT Villa", 78, 590.37, 43105, null },
                    { -85, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(417), "KBIHCK QRHYHVHWF", "", "NV Villa", 76, 957.30999999999995, 32231, null },
                    { -84, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(403), " IHHSZWCUXWTDAH", "", "STAK Villa", 33, 858.00999999999999, 8717, null },
                    { -83, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(388), "BCQRMSHHGTKQQTBCPUA", "", "XSAXIL Villa", 54, 391.22000000000003, 35749, null },
                    { -82, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(372), "OJNIQNFVAQYJQLLJ", "", "AW Villa", 77, 921.58000000000004, 35845, null },
                    { -81, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(358), "UJJKJQUSHR", "", "FBTWZZ Villa", 29, 280.0, 14252, null },
                    { -80, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(345), "KNDSULWEIKTFKV", "", "YRTV Villa", 90, 718.64999999999998, 18088, null },
                    { -79, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(331), " MQYEITQNWVTQGHY", "", "LIOB Villa", 85, 324.75, 18470, null },
                    { -78, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(317), "USWRLQXMSP", "", "GNXRQIP Villa", 9, 486.79000000000002, 27759, null },
                    { -77, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(280), "DXWOFZWAZDIEVGMMZNO", "", "SRHKCNX Villa", 4, 998.46000000000004, 7164, null },
                    { -76, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(264), "DVGHO ITVVX", "", "OWOQCL Villa", 70, 844.22000000000003, 28968, null },
                    { -75, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(251), "XODJIQDFTDCMCRNAPOQ", "", "NF Villa", 50, 717.34000000000003, 8926, null },
                    { -74, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(237), "FTVPXWUVFR", "", "YY Villa", 56, 872.57000000000005, 10729, null },
                    { -73, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(226), "GSSFXMCBRSHDE", "", "TJXVUKR Villa", 53, 935.05999999999995, 24238, null },
                    { -72, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(213), "VCKAOMAKNR", "", "AHHRJR Villa", 28, 971.26999999999998, 22659, null },
                    { -71, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(200), "QNVAJRV JEBGPZ YU", "", "YVHSVIO Villa", 48, 284.82999999999998, 25511, null },
                    { -70, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(184), "ULCZBHRYJXZRCZYM", "", "ZSHGY Villa", 52, 366.06999999999999, 38552, null },
                    { -69, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(169), "YVGQBFWP JCID", "", "HNIY Villa", 68, 573.88999999999999, 41433, null },
                    { -68, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(156), "CGOZG  PVJNMNM", "", "LKUYOWN Villa", 23, 997.08000000000004, 15803, null },
                    { -67, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(141), "FMIIQZPPCF EHY", "", "XEAA Villa", 15, 687.36000000000001, 36897, null },
                    { -66, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(126), "ZJFAVRS IMX HT", "", "RR Villa", 71, 289.67000000000002, 2820, null },
                    { -65, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(89), "IH RNJQLFRD BCKDO", "", "KNXFP Villa", 97, 475.73000000000002, 1534, null },
                    { -64, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(74), "VIH NUVKJYBNBJSQBR", "", "LIA Villa", 34, 804.15999999999997, 47341, null },
                    { -63, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(60), "BTFOMO ATQSMJNFB", "", "ZOPBGWH Villa", 90, 884.96000000000004, 7658, null },
                    { -62, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(45), "XYOPQMEAHYPRKT", "", "GA Villa", 66, 609.10000000000002, 12176, null },
                    { -61, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(32), "BMA WQJULJJSJJKIW ", "", "BFAOA Villa", 99, 230.25999999999999, 32451, null },
                    { -60, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(16), "XIMPWKWGDZZQV", "", "QCOT Villa", 53, 307.77999999999997, 41102, null },
                    { -59, "", new DateTime(2024, 7, 7, 13, 56, 36, 933, DateTimeKind.Local).AddTicks(3), "FJNRMVASZWZJEVLUWRF", "", "YIHJRKN Villa", 68, 247.91, 35138, null },
                    { -58, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9985), "USAPMUCLWTZMXNXNM", "", "RQIG Villa", 75, 240.22, 22908, null },
                    { -57, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9970), "XSVUFA TIJKCXOLTFAN", "", "AENDKT Villa", 54, 181.08000000000001, 22608, null },
                    { -56, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9930), "JTONNHWXRCUUWFSGUL", "", "FPK Villa", 23, 469.01999999999998, 47190, null },
                    { -55, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9915), "XMYASITMTTQIVJBPCF", "", "MSCWOJM Villa", 41, 933.62, 25904, null },
                    { -54, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9898), "XQHUJWN JYMIEC", "", "LUYB Villa", 51, 872.19000000000005, 20385, null },
                    { -53, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9885), "HM NLONIYODBXDJ", "", "ID Villa", 90, 945.90999999999997, 7094, null },
                    { -52, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9873), "MUUNRIECSIC OWKLTO", "", "OBMWY Villa", 64, 443.05000000000001, 43781, null },
                    { -51, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9857), "MBIGNHTWGZOYMRH", "", "GXP Villa", 44, 557.35000000000002, 29287, null },
                    { -50, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9844), "MJRZKGKS WCF", "", "CH Villa", 73, 234.30000000000001, 7401, null },
                    { -49, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9833), "ZLRAUXCVNUHR", "", "RMSFR Villa", 58, 598.25, 36861, null },
                    { -48, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9819), " CLEKKEESIZMWZ", "", "QD Villa", 4, 563.32000000000005, 13495, null },
                    { -47, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9806), "FUSRUQGYAOGFY", "", "KW Villa", 12, 144.71000000000001, 37953, null },
                    { -46, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9793), "GZUUY SRTX", "", "UK Villa", 78, 154.74000000000001, 35523, null },
                    { -45, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9783), "PNALABFLQVUBBKVLNS", "", "FWDK Villa", 2, 489.77999999999997, 36058, null },
                    { -44, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9732), "UZSQWLGYCKE", "", "PDSJM Villa", 95, 713.91999999999996, 45834, null },
                    { -43, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9719), "VTN WYEKVPPLJRVW", "", "NFDTMU Villa", 56, 725.14999999999998, 4683, null },
                    { -42, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9704), "QQYKJIRH S LN", "", "YYR Villa", 59, 684.61000000000001, 22074, null },
                    { -41, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9691), "IRJBKALHPZUIRHVGIOQ", "", "PQBNEK Villa", 28, 492.14999999999998, 26085, null },
                    { -40, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9675), "ZZNDWZDYHO", "", "AV Villa", 51, 571.33000000000004, 37634, null },
                    { -39, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9664), "TC NOUEWBG MSRAG", "", "BCH Villa", 4, 431.91000000000003, 11586, null },
                    { -38, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9650), "ISIVMGGCDMDVWUNSFG", "", "XRZ Villa", 33, 343.17000000000002, 26048, null },
                    { -37, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9635), "CYSMUJ FOQRTAY QRA", "", "LXWBAW Villa", 72, 349.74000000000001, 15365, null },
                    { -36, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9619), "MVHDJRRUWDBWQNOJQ", "", "HXXMEPZ Villa", 51, 789.70000000000005, 7688, null },
                    { -35, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9602), "OCXMEFCPXVCSRSZXG", "", "TCDCWKO Villa", 58, 842.26999999999998, 5030, null },
                    { -34, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9586), "ZECRUV W ZUP", "", "FBMBX Villa", 37, 125.81999999999999, 41530, null },
                    { -33, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9515), "OTLKQBCAJGNAAVWFYAC", "", "TDTLI Villa", 44, 396.47000000000003, 15077, null },
                    { -32, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9498), "OHMRNGGR JB", "", "SNBE Villa", 56, 549.66999999999996, 33065, null },
                    { -31, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9487), "FBZOHZFCPCUATGI", "", "UTX Villa", 11, 655.45000000000005, 31277, null },
                    { -30, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9474), "EIEDJVZIXCW", "", "NICL Villa", 5, 362.58999999999997, 30154, null },
                    { -29, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9461), "TYBPCCNYWMNWWGPMIT", "", "AKWP Villa", 14, 124.67, 32869, null },
                    { -28, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9446), "TAIQNKVCESSRNE", "", "XDUVBHA Villa", 92, 822.82000000000005, 46358, null },
                    { -27, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9431), "X OENFVVJHVYTKICRG", "", "LXED Villa", 83, 361.60000000000002, 38682, null },
                    { -26, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9416), "NCQUUXHPRIXP EDU", "", "KACZV Villa", 26, 878.86000000000001, 11301, null },
                    { -25, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9400), "RQZH CAIXAA", "", "RZSYMZZ Villa", 56, 482.94, 9008, null },
                    { -24, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9387), "VXKDGOPQCNUANXVJRMB", "", "MXLA Villa", 78, 844.65999999999997, 2388, null },
                    { -23, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9372), "GUIWCUXZHFYFHUZ UQC", "", "LN Villa", 30, 816.67999999999995, 43259, null },
                    { -22, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9342), "SODMZVONKFQE", "", "JVO Villa", 93, 494.16000000000003, 49399, null },
                    { -21, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9329), "LRZEGDHVTJRB", "", "QJKQRK Villa", 86, 786.94000000000005, 30836, null },
                    { -20, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9315), "WAHCVATZ XWOAOUG", "", "XQSJCD Villa", 62, 786.66999999999996, 6496, null },
                    { -19, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9300), "SXHBHFOXROICFP", "", "NEYNTI Villa", 73, 317.55000000000001, 46774, null },
                    { -18, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9284), "MGC LHBEPENNL", "", "HA Villa", 90, 222.38, 18539, null },
                    { -17, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9270), "WUFBVGMKMHOJOLR", "", "YIDMFX Villa", 90, 633.91999999999996, 6253, null },
                    { -16, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9256), "YHRXOYAIWOE", "", "CDM Villa", 16, 390.26999999999998, 26195, null },
                    { -15, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9244), "ZNMGASUMPFX", "", "MVFMR Villa", 24, 209.66, 11803, null },
                    { -14, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9231), "JKCGWVMPFSIOZZL", "", "XTORA Villa", 32, 164.88999999999999, 30250, null },
                    { -13, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9216), "HMV WMKBLCMKL", "", "NTOCX Villa", 99, 910.73000000000002, 49202, null },
                    { -12, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9201), "XCQDRME FJOWLVCVX", "", "YUXT Villa", 35, 594.95000000000005, 31424, null },
                    { -11, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9161), "RSFN KPHFJAIUOPQ", "", "XKIK Villa", 48, 962.12, 863, null },
                    { -10, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9146), "EXYJQXEGTXOFIPZEF", "", "SLK Villa", 90, 562.13999999999999, 28912, null },
                    { -9, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9131), "CHKEEKLOCM QRARSYDI", "", "DQXHZTS Villa", 46, 751.53999999999996, 30529, null },
                    { -8, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9113), "WDGAQRQFGGX", "", "NON Villa", 84, 865.83000000000004, 23948, null },
                    { -7, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9100), "VJEU   ZIPPIFBH", "", "EFRRKFT Villa", 78, 190.24000000000001, 9636, null },
                    { -6, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9084), "NXXPFMFOKRSXFXWTJ ", "", "FNPY Villa", 22, 192.08000000000001, 16378, null },
                    { -5, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9067), "VHSJGPKILKGXFD", "", "RW Villa", 97, 241.36000000000001, 22829, null },
                    { -4, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9053), "ZYRAFJEDLTO", "", "RARINBN Villa", 45, 401.43000000000001, 3701, null },
                    { -3, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9039), "PUVBKVSSRFBXSZH ", "", "GL Villa", 76, 695.66999999999996, 26020, null },
                    { -2, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(9023), "NBORW ODYOV", "", "REW Villa", 28, 773.17999999999995, 29141, null },
                    { -1, "", new DateTime(2024, 7, 7, 13, 56, 36, 932, DateTimeKind.Local).AddTicks(8883), "SXX XAXIBYJUZYEZCU", "", "QIJGLDY Villa", 60, 888.83000000000004, 3616, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -99);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -98);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -97);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -96);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -95);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -94);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -93);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -92);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -91);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -90);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -89);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -88);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -87);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -86);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -85);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -84);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -83);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -82);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -81);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -80);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -79);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -78);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -77);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -76);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -75);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -74);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -73);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -72);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -71);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -70);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -69);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -68);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -67);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -66);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -65);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -64);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -63);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -62);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -61);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -60);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -59);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -58);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -57);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -56);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -55);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -54);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -53);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -52);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -51);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -50);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -49);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -48);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -47);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -46);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -45);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -44);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -43);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -42);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -41);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -40);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -39);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -38);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -37);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -36);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -35);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -34);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -33);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -32);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -31);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -30);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -29);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -28);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -27);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -26);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -25);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -24);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -23);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -22);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -21);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -20);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -19);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -18);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -17);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -16);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -15);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -14);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -13);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -12);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -11);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -10);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -9);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -8);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
