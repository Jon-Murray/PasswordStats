using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordStats
{
    class Program
    {

     

        #region Common Words

        private static List<string> Months = new List<string>()
            {
                "january",
                "february",
                "march",
                "april",
                "may",
                "june",
                "july",
                "august",
                "september",
                "october",
                "november",
                "december"
            };

        private static List<string> Names = new List<string>() // top 100 names of 2016
        {
    "amelia",
"olivia",
"isla",
"emily",
"poppy",
"ava",
"isabella",
"jessica",
"lily",
"sophie",
"grace",
"sophia",
"mia",
"evie",
"ruby",
"ella",
"scarlett",
"isabelle",
"chloe",
"sienna",
"freya",
"phoebe",
"charlotte",
"daisy",
"alice",
"florence",
"eva",
"sofia",
"millie",
"lucy",
"evelyn",
"elsie",
"rosie",
"imogen",
"lola",
"matilda",
"elizabeth",
"layla",
"holly",
"lilly",
"molly",
"erin",
"ellie",
"maisie",
"maya",
"abigail",
"eliza",
"georgia",
"jasmine",
"esme",
"willow",
"bella",
"annabelle",
"ivy",
"amber",
"emilia",
"emma",
"summer",
"hannah",
"eleanor",
"harriet",
"rose",
"amelie",
"lexi",
"megan",
"gracie",
"zara",
"lacey",
"martha",
"anna",
"violet",
"darcey",
"maria",
"maryam",
"brooke",
"aisha",
"katie",
"leah",
"thea",
"darcie",
"hollie",
"amy",
"mollie",
"heidi",
"lottie",
"bethany",
"francesca",
"faith",
"harper",
"nancy",
"beatrice",
"isabel",
"darcy",
"lydia",
"sarah",
"sara",
"julia",
"victoria",
"zoe",
"robyn",
"boys:",
"oliver",
"jack",
"harry",
"jacob",
"charlie",
"thomas",
"george",
"oscar",
"james",
"william",
"noah",
"alfie",
"joshua",
"muhammad",
"henry",
"leo",
"archie",
"ethan",
"joseph",
"freddie",
"samuel",
"alexander",
"logan",
"daniel",
"isaac",
"max",
"mohammed",
"benjamin",
"mason",
"lucas",
"edward",
"harrison",
"jake",
"dylan",
"riley",
"finley",
"theo",
"sebastian",
"adam",
"zachary",
"arthur",
"toby",
"jayden",
"luke",
"harley",
"lewis",
"tyler",
"harvey",
"matthew",
"david",
"reuben",
"michael",
"elijah",
"kian",
"tommy",
"mohammad",
"blake",
"luca",
"theodore",
"stanley",
"jenson",
"nathan",
"charles",
"frankie",
"jude",
"teddy",
"louie",
"louis",
"ryan",
"hugo",
"bobby",
"elliott",
"dexter",
"ollie",
"alex",
"liam",
"kai",
"gabriel",
"connor",
"aaron",
"frederick",
"callum",
"elliot",
"albert",
"leon",
"ronnie",
"rory",
"jamie",
"austin",
"seth",
"ibrahim",
"owen",
"caleb",
"ellis",
"sonny",
"robert",
"joey",
"felix",
"finlay"
        };

        private static List<string> Countries = new List<string>()
        {
"afghanistan",
"albania",
"algeria",
"american samoa",
"andorra",
"angola",
"anguilla",
"antarctica",
"antigua and barbuda",
"argentina",
"armenia",
"aruba",
"australia",
"austria",
"azerbaijan",
"bahamas",
"bahrain",
"bangladesh",
"barbados",
"belarus",
"belgium",
"belize",
"benin",
"bermuda",
"bhutan",
"bolivia",
"bosnia and herzegovina",
"botswana",
"bouvet island",
"brazil",
"british antarctic territory",
"british indian ocean territory",
"british virgin islands",
"brunei",
"bulgaria",
"burkina faso",
"burundi",
"cambodia",
"cameroon",
"canada",
"canton and enderbury islands",
"cape verde",
"cayman islands",
"central african republic",
"chad",
"chile",
"china",
"christmas island",
"cocos [keeling] islands",
"colombia",
"comoros",
"congo - brazzaville",
"congo - kinshasa",
"cook islands",
"costa rica",
"croatia",
"cuba",
"cyprus",
"czech republic",
"côte d’ivoire",
"denmark",
"djibouti",
"dominica",
"dominican republic",
"dronning maud land",
"east germany",
"ecuador",
"egypt",
"el salvador",
"equatorial guinea",
"eritrea",
"estonia",
"ethiopia",
"falkland islands",
"faroe islands",
"fiji",
"finland",
"france",
"french guiana",
"french polynesia",
"french southern territories",
"french southern and antarctic territories",
"gabon",
"gambia",
"georgia",
"germany",
"ghana",
"gibraltar",
"greece",
"greenland",
"grenada",
"guadeloupe",
"guam",
"guatemala",
"guernsey",
"guinea",
"guinea-bissau",
"guyana",
"haiti",
"heard island and mcdonald islands",
"honduras",
"hong kong sar china",
"hungary",
"iceland",
"india",
"indonesia",
"iran",
"iraq",
"ireland",
"isle of man",
"israel",
"italy",
"jamaica",
"japan",
"jersey",
"johnston island",
"jordan",
"kazakhstan",
"kenya",
"kiribati",
"kuwait",
"kyrgyzstan",
"laos",
"latvia",
"lebanon",
"lesotho",
"liberia",
"libya",
"liechtenstein",
"lithuania",
"luxembourg",
"macau sar china",
"macedonia",
"madagascar",
"malawi",
"malaysia",
"maldives",
"mali",
"malta",
"marshall islands",
"martinique",
"mauritania",
"mauritius",
"mayotte",
"metropolitan france",
"mexico",
"micronesia",
"midway islands",
"moldova",
"monaco",
"mongolia",
"montenegro",
"montserrat",
"morocco",
"mozambique",
"myanmar [burma]",
"namibia",
"nauru",
"nepal",
"netherlands",
"netherlands antilles",
"neutral zone",
"new caledonia",
"new zealand",
"nicaragua",
"niger",
"nigeria",
"niue",
"norfolk island",
"north korea",
"north vietnam",
"northern mariana islands",
"norway",
"oman",
"pacific islands trust territory",
"pakistan",
"palau",
"palestinian territories",
"panama",
"panama canal zone",
"papua new guinea",
"paraguay",
"people's democratic republic of yemen",
"peru",
"philippines",
"pitcairn islands",
"poland",
"portugal",
"puerto rico",
"qatar",
"romania",
"russia",
"rwanda",
"réunion",
"saint barthélemy",
"saint helena",
"saint kitts and nevis",
"saint lucia",
"saint martin",
"saint pierre and miquelon",
"saint vincent and the grenadines",
"samoa",
"san marino",
"saudi arabia",
"senegal",
"serbia",
"serbia and montenegro",
"seychelles",
"sierra leone",
"singapore",
"slovakia",
"slovenia",
"solomon islands",
"somalia",
"south africa",
"south georgia and the south sandwich islands",
"south korea",
"spain",
"sri lanka",
"sudan",
"suriname",
"svalbard and jan mayen",
"swaziland",
"sweden",
"switzerland",
"syria",
"são tomé and príncipe",
"taiwan",
"tajikistan",
"tanzania",
"thailand",
"timor-leste",
"togo",
"tokelau",
"tonga",
"trinidad and tobago",
"tunisia",
"turkey",
"turkmenistan",
"turks and caicos islands",
"tuvalu",
"u.s. minor outlying islands",
"u.s. miscellaneous pacific islands",
"u.s. virgin islands",
"uganda",
"ukraine",
"union of soviet socialist republics",
"united arab emirates",
"united kingdom",
"united states",
"unknown or invalid region",
"uruguay",
"uzbekistan",
"vanuatu",
"vatican city",
"venezuela",
"vietnam",
"wake island",
"wallis and futuna",
"western sahara",
"yemen",
"zambia",
"zimbabwe"
        };

        private static List<string> Cities = new List<string>()
        {
            "tokyo",
"jakarta",
"new york ",
"seoul",
"manila",
"mumbai ",
"sao paulo",
"mexico city",
"delhi",
"osaka",
"cairo",
"kolkata ",
"los angeles ",
"shanghai",
"moscow",
"beijing ",
"buenos aires",
"guangzhou",
"shenzhen",
"istanbul",
"rio de janeiro",
"paris",
"karachi",
"nagoya",
"chicago ",
"lagos",
"london",
"bangkok",
"kinshasa",
"tehran",
"lima",
"dongguan",
"bogota",
"chennai ",
"dhaka",
"essen",
"tianjin ",
"hong kong",
"taipei",
"lahore",
"ho chi minh city ",
"bangalore",
"hyderabad",
"johannesburg",
"baghdad",
"toronto",
"santiago",
"kuala lumpur",
"san francisco ",
"philadelphia ",
"wuhan",
"miami ",
"dallas ",
"madrid",
"ahmedabad",
"boston ",
"belo horizonte",
"khartoum",
"saint petersburg ",
"shenyang",
"houston ",
"pune",
"riyadh",
"singapore",
"washington ",
"yangon ",
"milan ",
"atlanta ",
"chongqing",
"alexandria",
"nanjing ",
"guadalajara",
"barcelona",
"chengdu",
"detroit ",
"ankara",
"abidjan",
"athens",
"berlin",
"sydney",
"monterrey",
"phoenix ",
"busan ",
"recife",
"bandung",
"porto alegre",
"melbourne",
"luanda",
"hangzhou ",
"algiers",
"hà noi ",
"montréal",
"xi'an ",
"pyongyang",
"qingdao ",
"surat",
"fortaleza",
"medellín",
"durban",
"kanpur",
"addis ababa",
"nairobi",
"jeddah ",
"naples ",
"kabul",
"salvador",
"harbin ",
"kano",
"casablanca ",
"cape town",
"curitiba",
"surabaya",
"san diego ",
"seattle ",
"rome",
"dar es salaam",
"taichung",
"jaipur",
"caracas",
"dakar",
"kaohsiung",
"minneapolis ",
"lucknow",
"amman",
"tel aviv-yafo",
"guayaquil",
"kyiv ",
"faisalabad ",
"mashhad",
"izmir",
"rawalpindi",
"tashkent",
"katowice",
"changchun",
"campinas",
"daegu ",
"changsha",
"nagpur",
"san juan",
"aleppo",
"lisbon",
"frankfurt am main",
"nanchang",
"birmingham[] ",
"tampa ",
"medan",
"dalian",
"tunis",
"shijiazhuang",
"manchester",
"port-au-prince",
"damascus",
"ji'nan",
"fukuoka",
"santo domingo",
"havana",
"cali",
"denver ",
"st. louis ",
"colombo",
"dubai",
"baltimore ",
"sapporo",
"rotterdam",
"vancouver",
"preston",
"patna",
"sana'a",
"warsaw",
"bonn",
"accra",
"bucharest",
"yokohama",
"kunming",
"guiyang",
"zibo",
"incheon",
"zhengzhou",
"taiyuan",
"chaoyang ",
"brasilia",
"zhongshan",
"west midlands",
"giza",
"quezon city",
"nanhai",
"fuzhou ",
"lanzhou",
"xiamen",
"chittagong",
"zaozhuang",
"jilin",
"linyi",
"wenzhou",
"stockholm",
"puebla de zaragoza",
"puning",
"baku",
"ibadan",
"brisbane",
"minsk",
"sikasso",
"nanchong",
"nanning",
"urumqi",
"yantai",
"fuyang ",
"tangshan",
"maracaibo",
"hamburg",
"budapest",
"shunde",
"manaus",
"xuzhou",
"ségou",
"baotou",
"hefei",
"vienna",
"indore",
"asuncion",
"tianmen",
"belgrade",
"suzhou ",
"suizhou",
"nanyang",
"nakuru",
"koulikoro",
"ningbo",
"liuan",
"anshan",
"tengzhou",
"qiqihaer",
"pizhou",
"taian",
"datong",
"kobe",
"hama",
"esfahan",
"tripoli",
"west yorkshire",
"vadodara",
"taizhou ",
"luoyang",
"quito",
"jinjiang",
"mopti",
"perth",
"daejeon ",
"kyoto",
"xiantao",
"tangerang",
"bhopal",
"coimbatore",
"kharkiv",
"gwangju ",
"xinghua",
"harare",
"fushun",
"shangqiu",
"belém",
"wuxi",
"hechuan",
"wujin",
"guigang",
"jianyang ",
"huhehaote",
"santa cruz",
"semarang",
"ludhiana",
"novosibirsk",
"neijiang",
"maputo",
"nan'an",
"douala",
"weifang",
"daqing",
"kayes",
"tongzhou",
"tabriz",
"homs",
"rugao",
"guiping",
"huainan",
"kochi",
"suining",
"bozhou",
"zhanjiang",
"changde",
"montevideo",
"suzhou ",
"xintai",
"ekaterinoburg",
"juárez",
"handan",
"visakhapatnam",
"kawasaki",
"jiangjin",
"pingdu",
"agra",
"jiangyin",
"tijuana",
"liuyang",
"bursa",
"al-hasakeh",
"makkah",
"yaounde",
"xuanwei",
"dengzhou",
"palembang",
"nizhny novgorod",
"león ",
"guarulhos",
"heze",
"auckland",
"omdurman",
"shantou",
"leizhou",
"yongcheng",
"valencia",
"thane",
"san antonio ",
"xinyang",
"luzhou",
"almaty",
"changshu",
"taixing",
"phnom penh",
"laiwu",
"xiaoshan",
"yiyang",
"goiânia",
"liuzhou",
"gaozhou",
"fengcheng ",
"cixi",
"karaj",
"mogadishu",
"varanasi",
"córdoba",
"kampala",
"ruian",
"lianjiang",
"huaian",
"shiraz",
"multan",
"madurai",
"münchen",
"kalyan",
"quanzhou",
"adana",
"bazhong",
"fès",
"ouagadougou",
"haicheng",
"xishan",
"leiyang",
"caloocan",
"kalookan ",
"jingzhou",
"saitama",
"prague",
"fuqing",
"kumasi",
"meerut",
"hyderabad",
"lufeng",
"dongtai",
"yixing",
"mianyang",
"wenling",
"leqing",
"ottawa",
"yushu",
"barranquilla",
"hiroshima",
"chifeng",
"nashik",
"makasar ",
"sofia",
"rizhao",
"davao",
"tianshui",
"huzhou",
"samara ",
"omsk",
"gujranwala",
"adelaide",
"macheng",
"wuxian",
"bijie",
"yuzhou",
"leshan",
"la matanza",
"rosario",
"jabalpur",
"kazan",
"jimo",
"dingzhou",
"calgary",
"yerevan",
"el-jadida",
"jamshedpur",
"zürich",
"zoucheng",
"pikine-guediawaye",
"anqiu",
"guang'an",
"chelyabinsk",
"conakry",
"asansol",
"shouguang",
"changzhou",
"ulsan",
"zhuji",
"toluca ",
"marrakech",
"dhanbad",
"tbilisi",
"hanchuan",
"lusaka",
"qidong",
"faridabad",
"zaoyang",
"zhucheng",
"rostov-na-donu",
"jiangdu",
"xiangcheng",
"zigong",
"jining ",
"edmonton",
"allahabad",
"beiliu",
"dnipropetrovsk",
"gongzhuling",
"qinzhou",
"ufa",
"sendai",
"volgograd",
"ezhou",
"guatemala city",
"zhongxiang",
"amsterdam",
"brussels",
"bamako",
"ziyang",
"antananarivo",
"mudanjiang",
"amritsar",
"vijayawada",
"haora ",
"donetsk ",
"huazhou",
"fuzhou ",
"pimpri chinchwad",
"dublin",
"rajkot",
"sao luís",
"béni-mellal",
"lianyuan",
"liupanshui",
"kaduna",
"kitakyushu",
"qianjiang",
"perm",
"odessa",
"qom",
"yongchuan",
"peshawar",
"linzhou",
"benxi",
"ulaanbaatar",
"zhangqiu",
"yongzhou",
"sao gonçalo",
"srinagar",
"ghaziabad",
"xinyi ",
"köln",
"zhangjiagang",
"wafangdian",
"xianyang",
"liaocheng",
"ahwaz",
"taishan",
"linhai",
"feicheng",
"suwon ",
"wuwei",
"haimen",
"san luis potosí",
"liling",
"xinhui",
"gaziantep",
"krasnoyarsk",
"chiba",
"voronezh",
"durg-bhilai nagar",
"ruzhou",
"maceió",
"yichun ",
"al-madinah",
"yulin ",
"seongnam",
"yueyang",
"yiwu",
"san jose ",
"jixi",
"managua",
"xinyi ",
"safi",
"guangyuan",
"soweto",
"zhangjiakou",
"baoding",
"cartagena",
"huludao",
"pingdingshan",
"torino",
"zengcheng",
"laiyang",
"qingzhou",
"aurangabad",
"lattakia",
"mérida",
"laizhou",
"thiruvananthapuram",
"weinan",
"wuchang",
"guangshui",
"gaizhou",
"göteborg",
"xiaogan",
"torreón",
"jiaxing",
"kozhikode",
"salé",
"zhuzhou",
"tyneside",
"hengyang",
"dehui",
"honghu",
"danyang",
"daye",
"solapur",
"xingning",
"xiangfan",
"shubra-el-khema",
"luoding",
"gwalior",
"ranchi",
"huiyang",
"mombasa",
"jinzhou ",
"jiangyan",
"chenghai",
"jiamusi",
"songzi",
"tegucigalpa",
"wujiang",
"jodhpur",
"duque de caxias",
"xi'ning",
"yuyao",
"hezhou",
"jiangyou",
"tiruchchirappalli",
"baoshan",
"saratov",
"nova iguaçu",
"ankang",
"gaomi",
"yangchun",
"santiago de los caballeros",
"danzhou",
"la paz",
"zhuanghe",
"zhuhai",
"zhaodong",
"sakai",
"haikou",
"jiaonan",
"el alto",
"xuancheng",
"wuchuan",
"yuhang",
"qinhuangdao",
"bogor",
"kermanshah",
"longhai",
"liverpool",
"yanshi",
"guwahati",
"yichun ",
"konya",
"barquisimeto",
"yingde",
"bengbu",
"yibin",
"chandigarh",
"xiangxiang",
"yinchuan",
"valencia",
"guilin",
"hamamatsu",
"sao bernardo do campo",
"deir el-zor",
"bishkek",
"teresina",
"suihua",
"benghazi",
"jiutai",
"meishan",
"zaporizhya",
"gaoyou",
"marseille",
"kaifeng",
"changning",
"tongliao",
"natal",
"bandar lampung",
"dongying",
"gaoan",
"langzhong",
"lichuan",
"hubli-dharwad",
"mysore",
"niigata",
"indianapolis ",
"jiaozhou",
"pingxiang ",
"haiphong",
"arequipa",
"jacksonville ",
"tanger",
"dandong",
"kishinev",
"krasnodar",
"zagreb",
"xinmi",
"chaohu",
"xinyu",
"gongyi",
"huixian",
"xinxiang",
"port elizabeth",
"mendoza",
"nantong",
"pengzhou",
"khulna",
"malang",
"padang",
"anyang",
"renqiu",
"foshan",
"anshun",
"chihuahua",
"campo grande",
"lódz",
"goyang",
"benin city",
"bucheon ",
"gaocheng",
"pulandian",
"hejian",
"dafeng",
"kraków",
"enshi",
"dongyang",
"lviv",
"kunshan",
"shuangcheng",
"salem",
"jiaozuo",
"ad-dammam",
"huaibei",
"liyang",
"samut prakan",
"rongcheng",
"cenxi",
"nampho",
"columbus ",
"bareilly",
"leping",
"laixi",
"liaoyang",
"zhaotong",
"jerusalem",
"tainan",
"cuernavaca",
"riga",
"linfen",
"québec",
"lingbao",
"shangyu",
"wuan",
"hailun",
"xingyi",
"wuxue",
"cebu",
"aguascalientes",
"tolyatti",
"hamilton",
"zhoushan",
"langfang",
"osasco",
"nonthaburi",
"dashiqiao",
"tongxiang",
"yichang",
"yangzhou",
"blantyre city",
"hamhung",
"jalandhar",
"al-rakka",
"niamey",
"xiangtan",
"winnipeg",
"oran ",
"kota",
"sevilla",
"navi mumbai ",
"port harcourt",
"saltillo",
"khartoum north",
"shizuoka",
"yuanjiang",
"raipur",
"kryviy rig",
"yingkou",
"wuhu",
"zhenjiang",
"querétaro",
"nankang",
"wugang ",
"hegang",
"linqing",
"pretoria",
"zunyi",
"panzhihua",
"austin ",
"changle",
"lianyungang",
"yancheng",
"zunhua",
"changyi",
"meknès",
"qiongshan",
"bulawayo",
"wendeng",
"okayama",
"santo andré",
"rabat",
"pakanbaru",
"nehe",
"memphis ",
"joao pessoa",
"kathmandu",
"longkou",
"shengzhou",
"antalya",
"kumamoto",
"lilongwe",
"mexicali",
"kaiping",
"palermo",
"aligarh",
"nottingham",
"haining",
"mosul",
"hermosillo",
"tongcheng",
"shulan",
"miluo",
"bhubaneswar",
"yangquan",
"chenzhou",
"haiyang",
"morelia",
"huangshi ",
"xinmin",
"tétouan",
"barnaul",
"qixia",
"jaboatao dos guarapes",
"chongzhou",
"cotonou",
"yingcheng",
"zaragoza",
"changzhi",
"qujing",
"linghai",
"changge",
"trujillo",
"tampico",
"maoming",
"morón",
"la plata",
"ciudad guayana",
"moradabad",
"jieshou",
"sheffield",
"donggang",
"jingjiang",
"acheng",
"acapulco ",
"veracruz",
"ulyanovsk",
"wroclaw",
"jieyang",
"shaoxing",
"qian'an",
"nanchuan",
"qionglai",
"deyang",
"sagamihara",
"fuyang ",
"fuxin",
"jiyuan",
"puente alto",
"qufu",
"gaoyao",
"gorakhpur",
"fort worth ",
"xinji",
"san miguel de tucumán",
"dujiangyan",
"the hague",
"bhiwandi",
"culiacán rosales",
"lingyuan",
"xingyang",
"maiduguri",
"genova",
"meihekou",
"izhevsk",
"jeonju ",
"leling",
"xichang",
"colombo",
"zaria",
"anlu",
"sao josé dos campos",
"charlotte ",
"yizheng",
"malmö",
"weihai",
"xinzheng",
"dengfeng",
"vladivostok",
"shaoyang",
"taizhou ",
"jammu",
"lanxi",
"yuncheng",
"kagoshima",
"yaroslave",
"contagem",
"shishou",
"panjin",
"zamboanga",
"orumiyeh",
"binzhou",
"kisumu",
"baoji",
"uberlândia",
"el paso ",
"yunzhou",
"kénitra",
"diyarbakir",
"jurong",
"cúcuta",
"zhaoyuan",
"huizhou",
"tianchang",
"dortmund",
"shihezi",
"shiyan",
"cuttack",
"cochabamba",
"cheongju",
"jingmen",
"shangzhi",
"anqing",
"chongjin",
"stuttgart",
"rushan",
"kingston",
"milwaukee ",
"sorocaba",
"glasgow",
"khabarovsk",
"guanghan",
"warangal",
"irkutsk",
"tyumen",
"lomas de zamora",
"beipiao",
"funabashi",
"mingguang",
"düsseldorf",
"shenzhou",
"içel",
"zhangzhou",
"xianning",
"maanshan",
"bandjarmasin",
"callao",
"poznan",
"kayseri",
"chon buri",
"quetta",
"shuozhou",
"samarinda",
"helsinki",
"akesu",
"novokuznetsk",
"málaga",
"fengcheng ",
"hachioji",
"ribeirao prêto",
"beihai",
"jamnagar",
"nouakchott",
"bazhou",
"yongkang",
"louisville ",
"chizhou",
"huaiyin",
"fuan",
"bhilai nagar",
"dezhou",
"makhachkala",
"xingping",
"jiujiang",
"bristol",
"botou",
"fengnan",
"astana",
"yizhou",
"amravati",
"nashville-davidson ",
"batam",
"orenburg",
"zhuozhou",
"las vegas ",
"cancun",
"longyan",
"oslo",
"cuiabá",
"tiruppur",
"vilnius",
"bremen",
"gold coast-tweed",
"gaobeidian",
"mangalore",
"songyuan",
"yangjiang",
"wanyuan",
"jiangmen",
"xingtai",
"shaoguan",
"feira de santana",
"guixi",
"ruijin",
"zahedan",
"jinzhong",
"portland ",
"jintan",
"reynosa",
"ilorin",
"oklahoma city ",
"nakhon ratchasima",
"n'djamena",
"shangzhou",
"panshi",
"kerman",
"kaiyuan ",
"islamabad",
"sarajevo",
"bikaner",
"dushanbe",
"vientiane",
"dehradun",
"zhangshu",
"beining",
"abu dhabi",
"shimkent",
"xingcheng",
"imbaba",
"yicheng",
"skoplje",
"kadhimain",
"at-ta'if",
"dali",
"fuding",
"jinzhou ",
"renhuai",
"mira-bhayandar",
"kemerovo",
"duisburg",
"rasht"
        };

        private static List<string> SportsTeams = new List<string>()
        {
            "portsmouth",
"blackburnrovers",
"burnley",
"watford",
"middlesbrough",
"birminghamcity",
"wolverhamptonwanderers",
"sheffieldwednesday",
"norwichcity",
"crystalpalace",
"derby",
"leedsunited",
"glasgowrangers",
"rangers",
"westbromwichalbion",
"stokecity",
"leicestercity",
"sunderland",
"westhamunited",
"astonvilla",
"celtic",
"newcastleunited",
"everton",
"tottenhamhotspur",
"tottenham",
"liverpool",
"manchestercity",
"manchesterunited",
"chelsea",
"arsenal",
"manunited",
"mancity",
"angels",
"ducks",
"mightyducks",
"cardinals",
"diamondbacks",
"braves",
"falcons",
"hawks",
"orioles",
"ravens",
"bruins",
"celtics",
"redsox",
"dodgers",
"bills",
"sabres",
"flames",
"hurricanes",
"panthers",
"hornets",
"bears",
"blackhawks",
"bulls",
"cubs",
"whitesox",
"bengals",
"reds",
"browns",
"cavaliers",
"cavs",
"indians",
"avalanche",
"rockies",
"cowboys",
"mavs",
"stars",
"dallas mavericks",
"broncos",
"nuggets",
"lions",
"redwings",
"tigers",
"pistons",
"oilers",
"marlins",
"panthers",
"warriors",
"packers",
"warriors",
"astros",
"oilers",
"rockets",
"pacers",
"colts",
"jaguars",
"chiefs",
"royals",
"chiefs",
"royals",
"clippers",
"dodgers",
"kings",
"lakers",
"clippers",
"dodgers",
"kings",
"lakers",
"dolphins",
"heat",
"brewers",
"bucks",
"timberwolves",
"twins",
"twolves",
"canadiens",
"expos",
"patriots",
"devils",
"nets",
"saints",
"giants",
"islanders",
"jets",
"knicks",
"mets",
"rangers",
"yankees",
"devils",
"nets",
"giants",
"islanders",
"jets",
"knicks",
"mets",
"rangers",
"yankees",
"athletics",
"raiders",
"magic",
"senators",
"76ers",
"eagles",
"flyers",
"phillies",
"76ers",
"flyers",
"coyotes",
"suns",
"penguins",
"pirates",
"steelers",
"trailblazers",
"kings",
"spurs",
"chargers",
"padres",
"49ers",
"sharks",
"chargers",
"padres",
"seahawks",
"sonics",
"supersonics",
"blues",
"rams",
"buccaneers",
"bucs",
"devilrays",
"lightning",
"oilers",
"rangers",
"bluejays",
"mapleleafs",
"raptors",
"jazz",
"canucks",
"grizzlies",
"capitals",
"redskins",
"wizards"
        };

        private static List<string> Seasons = new List<string>()
        {
            "spring",
            "summer",
            "autumn",
            "winter"
        };

        private static List<string> SwearWords = new List<string>()
        {
            "arse",
"bloody",
"bugger",
"cow",
"crap",
"damn",
"ginger",
"git",
"god",
"goddam",
"jesuschrist",
"minger",
"sod-off",
"arsehole",
"balls",
"bint",
"bitch",
"bollocks",
"bullshit",
"feck",
"munter",
"pissed/pissedoff",
"shit",
"sonofabitch",
"tits",
"bastard",
"beaver",
"beefcurtains",
"bellend",
"bloodclaat",
"clunge",
"cock",
"dick",
"dickhead",
"fanny",
"flaps",
"gash",
"knob",
"minge",
"prick",
"punani",
"pussy",
"snatch",
"twat",
"cunt",
"fuck",
"motherfucker",
"bukkake",
"cocksucker",
"dildo",
"jizz",
"ho",
"nonce",
"prickteaser",
"rapey",
"skank",
"slag",
"slut",
"wanker",
"whore",
"2g1c",
"2girls1cup",
"acrotomophilia",
"alabamahotpocket",
"alaskanpipeline",
"anal",
"anilingus",
"anus",
"apeshit",
"arsehole",
"ass",
"asshole",
"assmunch",
"autoerotic",
"autoerotic",
"babeland",
"babybatter",
"babyjuice",
"ballgag",
"ballgravy",
"ballkicking",
"balllicking",
"ballsack",
"ballsucking",
"bangbros",
"bareback",
"barelylegal",
"barenaked",
"bastard",
"bastardo",
"bastinado",
"bbw",
"bdsm",
"beaner",
"beaners",
"beavercleaver",
"beaverlips",
"bestiality",
"bigblack",
"bigbreasts",
"bigknockers",
"bigtits",
"bimbos",
"birdlock",
"bitch",
"bitches",
"blackcock",
"blondeaction",
"blondeonblondeaction",
"blowjob",
"blowjob",
"blowyourload",
"bluewaffle",
"blumpkin",
"bollocks",
"bondage",
"boner",
"boob",
"boobs",
"bootycall",
"brownshowers",
"brunetteaction",
"bukkake",
"bulldyke",
"bulletvibe",
"bullshit",
"bunghole",
"bunghole",
"busty",
"butt",
"buttcheeks",
"butthole",
"cameltoe",
"camgirl",
"camslut",
"camwhore",
"carpetmuncher",
"carpetmuncher",
"chocolaterosebuds",
"circlejerk",
"clevelandsteamer",
"clit",
"clitoris",
"cloverclamps",
"clusterfuck",
"cock",
"cocks",
"coprolagnia",
"coprophilia",
"cornhole",
"coon",
"coons",
"creampie",
"cum",
"cumming",
"cunnilingus",
"cunt",
"darkie",
"daterape",
"daterape",
"deepthroat",
"deepthroat",
"dendrophilia",
"dick",
"dildo",
"dingleberry",
"dingleberries",
"dirtypillows",
"dirtysanchez",
"doggiestyle",
"doggiestyle",
"doggystyle",
"doggystyle",
"dogstyle",
"dolcett",
"domination",
"dominatrix",
"dommes",
"donkeypunch",
"doubledong",
"doublepenetration",
"dpaction",
"dryhump",
"dvda",
"eatmyass",
"ecchi",
"ejaculation",
"erotic",
"erotism",
"escort",
"eunuch",
"faggot",
"fecal",
"felch",
"fellatio",
"feltch",
"femalesquirting",
"femdom",
"figging",
"fingerbang",
"fingering",
"fisting",
"footfetish",
"footjob",
"frotting",
"fuck",
"fuckbuttons",
"fuckthis",
"fuckyou",
"fuckin",
"fucking",
"fucktards",
"fudgepacker",
"fudgepacker",
"futanari",
"gangbang",
"gaysex",
"genitals",
"giantcock",
"girlon",
"girlontop",
"girlsgonewild",
"goatcx",
"goatse",
"goddamn",
"gokkun",
"goldenshower",
"goodpoop",
"googirl",
"goregasm",
"grope",
"groupsex",
"g-spot",
"guro",
"handjob",
"handjob",
"hardcore",
"hardcore",
"hentai",
"homoerotic",
"honkey",
"hooker",
"hotcarl",
"hotchick",
"howtokill",
"howtomurder",
"hugefat",
"humping",
"incest",
"intercourse",
"jackoff",
"jailbait",
"jailbait",
"jellydonut",
"jerkoff",
"jigaboo",
"jiggaboo",
"jiggerboo",
"jizz",
"juggs",
"kike",
"kinbaku",
"kinkster",
"kinky",
"knobbing",
"leatherrestraint",
"leatherstraightjacket",
"lemonparty",
"lolita",
"lovemaking",
"makemecome",
"malesquirting",
"masturbate",
"menageatrois",
"milf",
"missionaryposition",
"motherfucker",
"moundofvenus",
"mrhands",
"muffdiver",
"muffdiving",
"nambla",
"nawashi",
"negro",
"neonazi",
"nigga",
"nigger",
"nignog",
"nimphomania",
"nipple",
"nipples",
"nsfwimages",
"nude",
"nudity",
"nympho",
"nymphomania",
"octopussy",
"omorashi",
"onecuptwogirls",
"oneguyonejar",
"orgasm",
"orgy",
"paedophile",
"paki",
"panties",
"panty",
"pedobear",
"pedophile",
"pegging",
"penis",
"phonesex",
"pieceofshit",
"pissing",
"pisspig",
"pisspig",
"playboy",
"pleasurechest",
"polesmoker",
"ponyplay",
"poof",
"poon",
"poontang",
"punany",
"poopchute",
"poopchute",
"porn",
"porno",
"pornography",
"princealbertpiercing",
"pthc",
"pubes",
"pussy",
"queaf",
"queef",
"quim",
"raghead",
"ragingboner",
"rape",
"raping",
"rapist",
"rectum",
"reversecowgirl",
"rimjob",
"rimming",
"rosypalm",
"rosypalmandher5sisters",
"rustytrombone",
"sadism",
"santorum",
"scat",
"schlong",
"scissoring",
"semen",
"sex",
"sexo",
"sexy",
"shavedbeaver",
"shavedpussy",
"shemale",
"shibari",
"shit",
"shitblimp",
"shitty",
"shota",
"shrimping",
"skeet",
"slanteye",
"slut",
"s&m",
"smut",
"snatch",
"snowballing",
"sodomize",
"sodomy",
"spic",
"splooge",
"sploogemoose",
"spooge",
"spreadlegs",
"spunk",
"strapon",
"strapon",
"strappado",
"stripclub",
"styledoggy",
"suck",
"sucks",
"suicidegirls",
"sultrywomen",
"swastika",
"swinger",
"taintedlove",
"tastemy",
"teabagging",
"threesome",
"throating",
"tiedup",
"tightwhite",
"tit",
"tits",
"titties",
"titty",
"tongueina",
"topless",
"tosser",
"towelhead",
"tranny",
"tribadism",
"tubgirl",
"tubgirl",
"tushy",
"twat",
"twink",
"twinkie",
"twogirlsonecup",
"undressing",
"upskirt",
"urethraplay",
"urophilia",
"vagina",
"venusmound",
"vibrator",
"violetwand",
"vorarephilia",
"voyeur",
"vulva",
"wank",
"wetback",
"wetdream",
"whitepower",
"wrappingmen",
"wrinkledstarfish",
"xx",
"xxx",
"yaoi",
"yellowshowers",
"yiffy",
"zoophilia"
        };

        private static List<string> DaysOfTheWeek = new List<string>()
        {
            "monday",
            "tuesday",
            "wednesday",
            "thursday",
            "friday",
            "saturday",
            "sunday"
        };

        private static List<string> InterestingWords = new List<string>()
        {
            "admin",
            "administrator",
            "superuser",
            "root",
            "poweruser",
            "guest",
            "service",
            "unattend"
        };

        #endregion

        private static Dictionary<char, char> Mappings = new Dictionary<char, char>();

        static void Main(string[] args)
        {
            var watch = Stopwatch.StartNew();
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: PasswordStats.exe <username:passwordFile> (optional) <logfile>");
                return;
            }

            string logFile = "";
            if (args.Length == 2)
            {
                logFile = args[1];

            }

            using (var cc = new ConsoleCopy(logFile))
            {

                Console.WriteLine();
                Console.WriteLine("Quick and dirty, any pull requests/improvements welcome. Give it a username:password file.");
                Console.WriteLine("https://github.com/Jon-Murray");
                Console.WriteLine();
                Console.WriteLine();

                if (args[0] == "-h" || args[0] == "--help")
                {
                    Console.WriteLine("give it a file in the format of username:password. Optionally specify a log file.....");
                    return;
                }

                var toStat = File.ReadAllLines(args[0]);

              

                bool johnMode = false;
                if (toStat.FirstOrDefault(x => x.Contains(":")) != null)
                {
                    johnMode = true;
                    //Console.WriteLine("Username:Password format file detected. Is this correct? Yes/No");
                    //var input = Console.ReadLine();
                    //johnMode = input == null || !input.ToLower().StartsWith("n");
                }
                else
                {
                    Console.WriteLine("Error: All lines need to be in the format of username:password.");
                    Console.WriteLine("Bailing.");
                    return;
                }

                List<string> usernames = new List<string>();
                List<string> tempPasses = new List<string>();

                if (johnMode)
                {
                    foreach (var stat in toStat)
                    {
                        if (stat == "")
                        {
                            continue;
                        }

                        var splat = stat.Split(':');
                        if (splat.Length < 2)
                        {
                            continue;
                        }

                        usernames.Add(splat[0]);

                        tempPasses.Add(string.Join(":", splat, 1, splat.Length - 1));
                    }

                    toStat = tempPasses.ToArray();

                    tempPasses.Clear();
                }

                // todo: how many follow the form of <number/s> letters
                // todo: how many follow the form of letters <number/s>
                // todo: how many follow the form of <number/s> letters <number/s>
                // todo: how many follow the form of letters <number/s> <special>
                // todo: how many follow the form of letters <special>

                var total = toStat.Length;
                Console.WriteLine("Analysing " + total + " passwords");

                // Create our 1337 mappings. These are basic, ie. "b" -> "8", not "|3", etc. feel free to change
                #region Mappings
                Mappings.Add('@', 'a');
                Mappings.Add('4', 'a');
                Mappings.Add('A', 'a');

                Mappings.Add('8', 'b');
                Mappings.Add('B', 'b');

                Mappings.Add('<', 'c');
                Mappings.Add('C', 'c');

                Mappings.Add('D', 'd');
                Mappings.Add('E', 'e');
                Mappings.Add('F', 'f');

                Mappings.Add('G', 'g');
                Mappings.Add('9', 'g');

                Mappings.Add('H', 'h');

                Mappings.Add('I', 'i');
                Mappings.Add('!', 'i');

                Mappings.Add('J', 'j');
                Mappings.Add('K', 'k');

                Mappings.Add('L', 'l');
                Mappings.Add('1', 'l');

                Mappings.Add('M', 'm');
                Mappings.Add('N', 'n');

                Mappings.Add('0', 'o');
                Mappings.Add('O', 'o');

                Mappings.Add('P', 'p');

                Mappings.Add('Q', 'q');
                Mappings.Add('R', 'r');

                Mappings.Add('S', 's');
                Mappings.Add('5', 's');
                Mappings.Add('$', 's');

                Mappings.Add('T', 't');
                Mappings.Add('7', 't');

                Mappings.Add('U', 'u');
                Mappings.Add('V', 'v');

                Mappings.Add('W', 'w');

                Mappings.Add('X', 'x');
                Mappings.Add('Y', 'y');

                Mappings.Add('Z', 'z');
                Mappings.Add('2', 'Z');
                #endregion

                // loop through and de-1337ify all the words
                var De1337ifiedStats = new ConcurrentDictionary<string, int>();
                var straightStats = new ConcurrentDictionary<string, int>();
                var commonBaseWord = new ConcurrentDictionary<string, int>();
                var passwordLengths = new ConcurrentDictionary<int, int>();
                var numDigits = new ConcurrentDictionary<int, int>();
                var numSpecials = new ConcurrentDictionary<string, int>();
                var passwordComposition = new ConcurrentDictionary<string, int>();
                var usernamesAsPasswordsStraight = new ConcurrentDictionary<string, int>();
                var usernamesAsPassword1337 = new ConcurrentDictionary<string, int>();
                var daysOfTheWeek = new ConcurrentDictionary<string, int>();
                var months = new ConcurrentDictionary<string, int>();
                var names = new ConcurrentDictionary<string, int>();
                var cities = new ConcurrentDictionary<string, int>();
                var countries = new ConcurrentDictionary<string, int>();
                var sportsTeams = new ConcurrentDictionary<string, int>();
                var seasons = new ConcurrentDictionary<string, int>();
                var swearWords = new ConcurrentDictionary<string, int>();
                var interestingPass = new ConcurrentDictionary<string, int>();


                Parallel.ForEach(toStat, (pass, sth, i) =>
                {
                // Create a list of our del337ified "base" words, ie. Passw0rd! -> password
                var de1337 = de1337ify(pass);
                    if (de1337.Length >= 3)
                    {
                        var deleetuser = de1337ify(usernames[(int)i]);
                        if (de1337 == deleetuser)
                        {
                            // if the username isn't the same as the password exactly (as this will get caught later on), add it
                            if (usernames[(int)i] != pass)
                            {
                                usernamesAsPassword1337.AddOrUpdate(usernames[(int)i] + ":" + pass, 1, (id, count) => count + 1);
                            }
                        }

                        if (InterestingWords.Contains(de1337))
                        {
                            interestingPass.AddOrUpdate(usernames[(int)i] + ":" + pass, 1, (id, count) => count + 1);
                        }
                    // if it is based on a month
                    if (Months.Contains(de1337))
                        {
                            months.AddOrUpdate(de1337, 1, (id, count) => count + 1);
                        }

                    // based on a name
                    if (Names.Contains(de1337))
                        {
                            names.AddOrUpdate(de1337, 1, (id, count) => count + 1);
                        }

                    // based on a city
                    if (Cities.Contains(de1337))
                        {
                            cities.AddOrUpdate(de1337, 1, (id, count) => count + 1);
                        }

                    // based on a country
                    if (Countries.Contains(de1337))
                        {
                            countries.AddOrUpdate(de1337, 1, (id, count) => count + 1);
                        }

                    // based on a sports team
                    if (SportsTeams.Contains(de1337))
                        {
                            sportsTeams.AddOrUpdate(de1337, 1, (id, count) => count + 1);
                        }

                    // Seasons
                    if (Seasons.Contains(de1337))
                        {
                            seasons.AddOrUpdate(de1337, 1, (id, count) => count + 1);
                        }

                    // Days of the week
                    if (DaysOfTheWeek.Contains(de1337))
                        {
                            daysOfTheWeek.AddOrUpdate(de1337, 1, (id, count) => count + 1);
                        }

                    // Swear words
                    if (SwearWords.Contains(de1337))
                        {
                            swearWords.AddOrUpdate(de1337, 1, (id, count) => count + 1);
                        }


                        De1337ifiedStats.AddOrUpdate(de1337, 1, (id, count) => count + 1);
                    }

                // Create a list of our actual words, ie. Password1234 -> password, P4ssword!! -> p4ssword
                var baseWord = getBaseWord(pass);
                    if (baseWord.Length >= 3)
                    {
                        commonBaseWord.AddOrUpdate(baseWord, 1, (id, count) => count + 1);
                    }
                // Create a list of the most popular passwords themselves (straight)
                straightStats.AddOrUpdate(pass, 1, (id, count) => count + 1);

                    if (usernames[(int)i]  == pass)
                    {
                        usernamesAsPasswordsStraight.AddOrUpdate(usernames[(int)i] + ":" + pass, 1, (id, count) => count + 1);
                    }

                // add the password length
                passwordLengths.AddOrUpdate(pass.Length, 1, (id, count) => count + 1);

                    int digitCount = 0;
                    int specialCount = 0;

                    foreach (var c in pass)
                    {
                        if (char.IsDigit(c))
                        {
                            digitCount++;
                        }

                        else if (!char.IsLetterOrDigit(c))
                        {
                            specialCount++;
                            numSpecials.AddOrUpdate(c.ToString(), 1, (id, count) => count + 1);
                        }

                        if (digitCount > 10)
                        {
                            break;
                        }
                    }

                    if (pass.All(char.IsLetter))
                    {
                        passwordComposition.AddOrUpdate("Letters Only", 1, (id, count) => count + 1);
                    }
                    else if (pass.All(char.IsLetterOrDigit))
                    {
                        passwordComposition.AddOrUpdate("Letters and Digits", 1, (id, count) => count + 1);
                    }
                    else if (pass.All(char.IsDigit))
                    {
                        passwordComposition.AddOrUpdate("Digits Only", 1, (id, count) => count + 1);
                    }
                    else if (pass.Any(x => char.IsLetterOrDigit(x)))
                    {
                        if (pass.All(x => !char.IsLetterOrDigit(x)))
                        {
                            passwordComposition.AddOrUpdate("Special Chars Only", 1, (id, count) => count + 1);
                        }
                        else if (pass.Any(x => char.IsLetterOrDigit(x)))
                        {
                            passwordComposition.AddOrUpdate("Letters, Digits, and Special Chars", 1, (id, count) => count + 1);
                        }
                        else if (pass.Any(x => char.IsLetter(x)) && pass.Any(x => !char.IsNumber(x)))
                        {
                            passwordComposition.AddOrUpdate("Letters and Special Chars Only", 1, (id, count) => count + 1);
                        }
                        else if (pass.Any(x => !char.IsLetter(x)) && pass.Any(x => char.IsNumber(x)))
                        {
                            passwordComposition.AddOrUpdate("Numbers and Special Chars Only", 1, (id, count) => count + 1);
                        }
                    }

                    if (pass.Any(x => char.IsLetter(x) && char.IsDigit(x)))
                    {
                    // Letters Digits and Special Chars
                    if (pass.Any(x => !char.IsLetterOrDigit(x)))
                        {
                            passwordComposition.AddOrUpdate("Letters Digits and Special Chars", 1, (id, count) => count + 1);
                        }
                    // Letters and Digits 
                    else
                        {
                        }
                    }

                    else if (pass.Any(x => char.IsDigit(x)))
                    {
                    // Special Chars and Digits
                    if (!pass.Any(x => char.IsLetter(x)))
                        {
                            passwordComposition.AddOrUpdate("Special Chars and Digits", 1, (id, count) => count + 1);
                        }
                    // Digits Only

                    else if (pass.All(char.IsDigit))
                        {
                            passwordComposition.AddOrUpdate("Digits Only", 1, (id, count) => count + 1);
                        }
                    }

                    numDigits.AddOrUpdate(digitCount, 1, (id, count) => count + 1);

                });

                Console.WriteLine();
                watch.Stop();
                Console.WriteLine("Done the analysis in " + watch.ElapsedMilliseconds / 1000 + " seconds (" + watch.ElapsedMilliseconds + " milliseconds).");
                Console.WriteLine();

                Console.WriteLine("Password lengths:");
                printIntStats(passwordLengths);

                Console.WriteLine("Password Composition:");
                printStats(passwordComposition, 10);

                Console.WriteLine("Top 25 passwords: ");
                printStats(straightStats, 25);

                Console.WriteLine("Top 20 common base words: ");
                printStats(commonBaseWord, 20);

                Console.WriteLine("Top 10 base words (including 1337 versions, ie. Pa55w0rd! -> password): ");
                printStats(De1337ifiedStats, 20);

                var shortestPasses = straightStats.OrderBy(x => x.Key.Length).ThenByDescending(x => x.Value).Take(10);
                var orderedshortestPasses = shortestPasses.OrderByDescending(s => s.Key.Length);

                // get longest output and add 5 chars
                var padWidth = orderedshortestPasses.First().Key.Length + 5;

                Console.WriteLine("Shortest 10 Passwords Cracked:");
                foreach (var o in shortestPasses)
                {
                    string str = o.Key;
                    string paddedString = str.PadRight(padWidth);
                    Console.WriteLine("\t{0}{1}", paddedString, o.Value + "(" + (int)Math.Round((double)(100 * o.Value) / total, 2) + "%) Length: " + o.Key.Length);
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

                var longestPasses = straightStats.OrderByDescending(x => x.Key.Length).ThenByDescending(x => x.Value).Take(10);
                var orderedlongestPasses = longestPasses.OrderByDescending(s => s.Key.Length);

                // get longest output and add 5 chars
                padWidth = orderedlongestPasses.First().Key.Length + 5;

                Console.WriteLine("Longest 10 Passwords Cracked:");
                foreach (var o in longestPasses)
                {
                    string str = o.Key;
                    string paddedString = str.PadRight(padWidth);
                    Console.WriteLine("\t{0}{1}", paddedString, o.Value + "(" + (int)Math.Round((double)(100 * o.Value) / total, 2) + "%) Length: " + o.Key.Length);
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("Days of the week passwords are a 1337 version of, or based on:");
                printStats(daysOfTheWeek, 12);

                Console.WriteLine("Months passwords are a 1337 version of, or based on:");
                printStats(months, 12);

                Console.WriteLine("Seasons passwords are a 1337 version of, or based on:");
                printStats(seasons, 4);

                Console.WriteLine("Top 25 common names passwords are a 1337 version of, or based on:");
                printStats(names, 25);


                Console.WriteLine("Top 25 countries passwords are a 1337 version of, or based on:");
                printStats(countries, 25);

                Console.WriteLine("Top 25 of the 1000 most populated cities passwords are a 1337 version of, or based on:");
                printStats(cities, 25);

                Console.WriteLine("Top 25 popular sports teams passwords are a 1337 version of, or based on:");
                printStats(sportsTeams, 25);

                Console.WriteLine("Top 10 swear words passwords are a 1337 version of, or based on:");
                printStats(swearWords, 10);

                Console.WriteLine("100 Interesting Username/Password combos identified:");
                printStats(interestingPass, 100);


                Console.WriteLine("Special Characters Seen:");
                printStats(numSpecials, 20);

                Console.WriteLine("Number of digits per password:");
                printIntStats(numDigits);

                Console.WriteLine("Users with the same username/password " + "(" + (int)Math.Round((double)(100 * usernamesAsPasswordsStraight.Count) / total, 2) + "%)");
                printStats(usernamesAsPasswordsStraight, 10000000);

                Console.WriteLine("Users with the a password which is a 1337/variation of their username " + "(" + (int)Math.Round((double)(100 * usernamesAsPassword1337.Count) / total, 2) + "%)");
                printStats(usernamesAsPassword1337, 10000000);

                Console.WriteLine("Do you wish to check stats against a password policy? Nb. this adheres to the windows password policy format, where string have three of the 4 with regards to complexity, upper, lower, and numeric (yes/no)");

                int minLength = 1;
                int minUpper = 0;
                int minSpecial = 0;
                int minNumeric = 0;

                var r = Console.ReadLine();
                if (r != null && r.ToLower().StartsWith("y"))
                {
                    Console.WriteLine("Enter minimum password length:");
                    minLength = int.Parse(Console.ReadLine());

                    Console.WriteLine("Require uppercase? (yes/no)");
                    if (Console.ReadLine().ToLower().StartsWith("y"))
                    {
                        Console.WriteLine("Do want to specify how many uppercase characters? (yes/no)");
                        if (Console.ReadLine().ToLower().StartsWith("y"))
                        {
                            minUpper = int.Parse(Console.ReadLine());
                        }
                        else
                        {
                            minUpper = 1;
                        }
                    }

                    Console.WriteLine("Enforce numeric characters? (yes/no)");

                    if (Console.ReadLine().ToLower().StartsWith("y"))
                    {
                        Console.WriteLine("Do want to specify how many numeric characters? (yes/no)");
                        if (Console.ReadLine().ToLower().StartsWith("y"))
                        {
                            minNumeric = int.Parse(Console.ReadLine());
                        }
                        else
                        {
                            minNumeric = 1;
                        }
                    }

                    Console.WriteLine("Enforce complexity? (yes/no)");

                    if (Console.ReadLine().ToLower().StartsWith("y"))
                    {
                        Console.WriteLine("Do want to specify how many special characters? (yes/no)");
                        if (Console.ReadLine().ToLower().StartsWith("y"))
                        {
                            minSpecial = int.Parse(Console.ReadLine());
                        }
                        else
                        {
                            minSpecial = 1;
                        }
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();

                    bool useUsernames = usernames.Count > 0;

                    for (int i = 0; i < toStat.Length; i++)
                    {
                        if (toStat[i].Length < minLength)
                        {
                            if (useUsernames)
                            {
                                Console.WriteLine(usernames[i] + ":" + toStat[i] + " (too short - " + toStat[i].Length + " characters)");
                            }
                            else
                            {
                                Console.WriteLine(toStat[i] + " (too short - " + toStat[i].Length + " characters)");
                            }

                            continue;
                        }

                        int numFailed = 0;


                        if (minUpper > 0 && toStat[i].Where(x => char.IsUpper(x)).Count() < minUpper)
                        {
                            numFailed++;
                        }

                        if (minSpecial > 0 && toStat[i].Where(x => !char.IsLetterOrDigit(x)).Count() < minSpecial)
                        {
                            numFailed++;
                        }

                        if (minNumeric > 0 && toStat[i].Where(x => !char.IsDigit(x)).Count() < minNumeric)
                        {
                            numFailed++;
                        }

                        if (minSpecial > 0)
                        {
                            if (numFailed > 1)
                            {
                                if (useUsernames)
                                {
                                    Console.WriteLine(usernames[i] + ":" + toStat[i]);
                                }
                                else
                                {
                                    Console.WriteLine(toStat[i]);
                                }
                            }
                        }
                        else
                        {
                            if (numFailed > 0)
                            {
                                if (useUsernames)
                                {
                                    Console.WriteLine(usernames[i] + ":" + toStat[i]);
                                }
                                else
                                {
                                    Console.WriteLine(toStat[i]);
                                }
                            }
                        }
                    }
                }


                Console.WriteLine("Done, press any key...");

                Console.ReadLine();

            }
        }
        /// <summary>
        /// Converts a word from 1337 to normal (lowercase). This will also trim the contigious numbers off the start/end
        /// ie. 123Passw0rd -> password
        /// Pa55w0rd1234 -> password
        /// </summary>
        /// <param name="unLeet"></param>
        /// <returns></returns>
        private static string de1337ify(string unLeet)
        {
            // if the password is quite obviously markov (ie. ends in 2 numbers, or just ends in a number like 123) do not try and de1337ify them
            // similarly, if the password starts with a number like 13tm31n, trim and reappend the number.
            // This might give a few false positives/negatives, but whatever

            int toTrim = 0;
            int toTrimStart = 0;

            for(int i = unLeet.Length -1; i > 0; i--)
            {
                if (char.IsNumber(unLeet[i]) || !char.IsLetter(unLeet[i])) // also trim off stuff on the end, like Passw0rd123!
                {
                    // sbEnd.Insert(0, unLeet[i]);
                    toTrim++;
                }
                else
                {
                    break;
                }
            }

            for(int i = 0; i< unLeet.Length; i++)
            {
                if (char.IsNumber(unLeet[i]) || !char.IsLetter(unLeet[i]))
                {
                    //sbStart.Append(unLeet[i]);
                    toTrimStart++;
                }
                else
                {
                    break;
                }
            }

            StringBuilder sb = new StringBuilder();

            for(int i = toTrimStart; i< unLeet.Length - toTrim; i++)
            {
                if (Mappings.ContainsKey(unLeet[i]))
                {
                    sb.Append(Mappings[unLeet[i]]);
                }
                else // some special character/word
                {
                    sb.Append(unLeet[i]);
                }
            }

            return sb.ToString().ToLower(); ;
        }

        /// <summary>
        /// Returns the "base" word to create the password. Ie. 
        /// Password -> password
        /// Passw0rd -> password
        /// Trims any numbers/symbols off the end of the word
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        private static string getBaseWord(string pass)
        {
            int toTrim = 0;

            for (int i = pass.Length - 1; i > 0; i--)
            {
                if (char.IsNumber(pass[i]) || !char.IsLetter(pass[i])) // also trim off stuff on the end, like Passw0rd123!
                {
                    // sbEnd.Insert(0, unLeet[i]);
                    toTrim++;
                }
                else
                {
                    break;
                }
            }

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < pass.Length - toTrim; i++)
            {
                if (Mappings.ContainsKey(pass[i]))
                {
                    sb.Append(Mappings[pass[i]]);
                }
                else // some special character/word
                {
                    sb.Append(pass[i]);
                }
            }

            return sb.ToString();
        }

        private static void printStats(ConcurrentDictionary<string, int> dict, int amount)
        {
            if (dict.Count == 0)
            {
                Console.WriteLine("0 Entries.");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                return;
            }

            var ordered = dict.OrderByDescending(v => v.Value).Take(amount).ToList();
            var total = dict.Values.Sum();

            Console.WriteLine();
            Console.WriteLine("\t" + total + " total.");
            Console.WriteLine();

            var orderedOutputs = ordered.OrderByDescending(s => s.Key.Length);


            // get longest output and add 5 chars
            var padWidth = orderedOutputs.First().Key.Length + 5;


            foreach (var o in ordered)
            {
                string str = o.Key;
                string paddedString = str.PadRight(padWidth);
                Console.WriteLine("\t{0}{1}", paddedString, o.Value + "(" + (int)Math.Round((double)(100 * o.Value) / total, 2) + "%)");
            }


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

        }

        /// <summary>
        /// Print all the values in a dict int string
        /// </summary>
        /// <param name="dict"></param>
        private static void printIntStats(ConcurrentDictionary<int, int> dict)
        {
            if (dict.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                return;
            }

            var ordered = dict.OrderBy(v => v.Key);
            var total = dict.Values.Sum();

            foreach (var o in ordered)
            {
                Console.WriteLine("\t{0}\t{1}", o.Key, o.Value + "(" + (int)Math.Round((double)(100 * o.Value) / total, 2) + "%)");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }


    }
}
