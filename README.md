# PasswordStats
A tool to gather more thorough password statistics from password dumps.

Recently, I was tasked to do a password audit of a large amount of passwords. The tools that were available before were missing several features which would give valuable insight into the users' passwords. I decided to make a quick tool to make use of these stats easily. Use in the form of "PasswordFile.exe <username:passwordfile><OptionalLogfile>"

Features:

    Length frequency
    Composition
    Top 25 passwords
    Top 20 common base words (ie. password123, password1 -> "password)
    Top 20 common de-1337ified words (ie. Pa$$w0rd, 123P455w0rd123 -> "password")
    Shortest 10 password cracked
    Longest 10 passwords cracked
    (de-1337) Days of week
    (de-1337) Months
    (de-1337) Seasons
    (de-1337) Common names (ie. m1cha3l, James123, etc.)
    (de-1337) Countries
    (de-1337) Cities
    (de-1337) Sports teams
    (de-1337) Swear words
    (de-1337) Interesting passwords (ie. r00t123, Administrat0r, etc.)
    Special Character frequency
    Digit frequency
    Users with the exact same username/password
    Users with a password which is a de-1337/variation of their username
    
    Then after this is all said/done there is a domain password audit mode. This is intended to emulate a Windows domain, so you can enter your password policy (ie. [all optional] min length 8, require x numeric, x upper) and then complexity. If complexity is entered then it will spit out a list of accounts and their passwords which do not adhere to the domain/password policy. This is to catch old service/machine/user accounts which have not been updated to a new password policy, but in reality this will never return any results, as this never happens, never ever...
    
    This is not written to be efficient, but it is written to be fast. Sets are loaded into memory, and multi threading is used, it is fairly resource intensive. I've had some benchmarks of 20k passwords = 130ms, 100k passwords = 616ms, 1mill = 6 seconds, 10mill = 73 seconds (purely processing, not writing to stdout) on my i7 laptop. I'd like to make this better/add more relevant stats. If anyone has any large datasets, or happens to bump in to troy hunt down the pub, please send them over!
    
    Cheers
    
Example usage on a 10k password file is below:


Quick and dirty, any pull requests/improvements welcome. Give it a username:password file.
https://github.com/Jon-Murray

C:\Users\John\Desktop\Code\Password Stats\PasswordStats\PasswordStats\bin\Release>PasswordStats.exe C:\Users\John\Downloads\10-million-combos\tosplit\xaa log.txt

Analysing 10000 passwords

Done the analysis in 0 seconds (97 milliseconds).

Password lengths:
	0	1(0%)
	3	8(0%)
	4	500(5%)
	5	584(5%)
	6	2549(25%)
	7	1496(14%)
	8	2860(28%)
	9	672(6%)
	10	538(5%)
	11	243(2%)
	12	186(1%)
	13	149(1%)
	14	87(0%)
	15	50(0%)
	16	30(0%)
	17	20(0%)
	18	10(0%)
	19	6(0%)
	20	4(0%)
	21	2(0%)
	24	1(0%)
	25	1(0%)
	26	1(0%)
	28	1(0%)
	29	1(0%)



Password Composition:

	11657 total.

	Letters and Digits                     5155(44%)
	Letters Only                           4724(40%)
	Special Chars and Digits               1658(14%)
	Letters, Digits, and Special Chars     120(1%)



Top 25 passwords: 

	10000 total.

	123456         60(0%)
	password       25(0%)
	26429vadim     17(0%)
	12345678       16(0%)
	123456789      13(0%)
	12345          13(0%)
	1234           9(0%)
	bianca         8(0%)
	iloveyou       8(0%)
	travis         7(0%)
	bibi           7(0%)
	football       7(0%)
	jennifer       7(0%)
	bs2010         6(0%)
	golf1953       6(0%)
	ubejal         6(0%)
	abc123         6(0%)
	baseball       6(0%)
	pussy          6(0%)
	brutus99       5(0%)
	george         5(0%)
	bunnii         5(0%)
	hercules       5(0%)
	sunshine       5(0%)
	genesis        5(0%)



Top 20 common base words: 

	8171 total.

	password       31(0%)
	bibi           24(0%)
	Z6aZgvadim     17(0%)
	bianca         17(0%)
	bha            16(0%)
	bia            15(0%)
	abc            10(0%)
	iloveyou       10(0%)
	summer         9(0%)
	football       9(0%)
	bibo           9(0%)
	golf           8(0%)
	baseball       8(0%)
	bill           8(0%)
	sunshine       7(0%)
	jennifer       7(0%)
	travis         7(0%)
	born           6(0%)
	bharat         6(0%)
	london         6(0%)



Top 10 base words (including 1337 versions, ie. Pa55w0rd! -> password): 

	8038 total.

	password     31(0%)
	bibi         26(0%)
	bia          19(0%)
	bianca       18(0%)
	vadim        17(0%)
	bha          16(0%)
	iloveyou     11(0%)
	bibo         11(0%)
	abc          10(0%)
	summer       9(0%)
	bill         9(0%)
	football     9(0%)
	golf         8(0%)
	baseball     8(0%)
	bhbyf        8(0%)
	sunshine     7(0%)
	pussy        7(0%)
	jennifer     7(0%)
	travis       7(0%)
	born         6(0%)



Shortest 10 Passwords Cracked:
	         1(0%) Length: 0
	paj      1(0%) Length: 3
	aba      1(0%) Length: 3
	abc      1(0%) Length: 3
	abb      1(0%) Length: 3
	zzz      1(0%) Length: 3
	262      1(0%) Length: 3
	7cP      1(0%) Length: 3
	cci      1(0%) Length: 3
	1234     9(0%) Length: 4



Longest 10 Passwords Cracked:
	barryraywhitehursthopeave1966     1(0%) Length: 29
	upscmpscgatecateseuescds2013      1(0%) Length: 28
	bhochudruzhitbhochudruzhit        1(0%) Length: 26
	BHOSXZNICMEDINA3436216321         1(0%) Length: 25
	lakersbhardwaj90chanchal          1(0%) Length: 24
	mytempuser-usemefor90             1(0%) Length: 21
	iloveyoubibi.01021997             1(0%) Length: 21
	chickenbidallastxguy              1(0%) Length: 20
	jack5579manja2636bib              1(0%) Length: 20
	almiine8564697779417              1(0%) Length: 20



Days of the week passwords are a 1337 version of, or based on:

	3 total.

	monday      2(66%)
	tuesday     1(33%)



Months passwords are a 1337 version of, or based on:

	11 total.

	may          3(27%)
	august       2(18%)
	march        2(18%)
	january      1(9%)
	april        1(9%)
	june         1(9%)
	november     1(9%)



Seasons passwords are a 1337 version of, or based on:

	10 total.

	summer     9(90%)
	spring     1(10%)



Top 25 common names passwords are a 1337 version of, or based on:

	135 total.

	summer       9(6%)
	george       5(3%)
	oliver       5(3%)
	benjamin     5(3%)
	michael      4(2%)
	dexter       4(2%)
	david        4(2%)
	harley       4(2%)
	charlie      4(2%)
	alex         4(2%)
	samuel       3(2%)
	maria        3(2%)
	daniel       3(2%)
	henry        3(2%)
	gabriel      3(2%)
	grace        3(2%)
	austin       3(2%)
	hannah       3(2%)
	arthur       3(2%)
	dylan        2(1%)
	poppy        2(1%)
	sarah        2(1%)
	alice        2(1%)
	jamie        2(1%)
	william      2(1%)



Top 25 countries passwords are a 1337 version of, or based on:

	17 total.

	india         4(23%)
	jordan        3(17%)
	canada        2(11%)
	belgium       1(5%)
	ireland       1(5%)
	bhutan        1(5%)
	ghana         1(5%)
	aruba         1(5%)
	italy         1(5%)
	argentina     1(5%)
	mexico        1(5%)



Top 25 of the 1000 most populated cities passwords are a 1337 version of, or based on:

	20 total.

	london        6(30%)
	berlin        3(15%)
	paris         2(10%)
	marseille     1(5%)
	hamilton      1(5%)
	shiraz        1(5%)
	bursa         1(5%)
	istanbul      1(5%)
	sydney        1(5%)
	cancun        1(5%)
	lahore        1(5%)
	haiphong      1(5%)



Top 25 popular sports teams passwords are a 1337 version of, or based on:

	49 total.

	packers      5(10%)
	rangers      4(8%)
	steelers     3(6%)
	magic        2(4%)
	arsenal      2(4%)
	bucks        2(4%)
	patriots     2(4%)
	dolphins     2(4%)
	bengals      2(4%)
	angels       2(4%)
	eagles       2(4%)
	cowboys      2(4%)
	saints       2(4%)
	panthers     1(2%)
	rockies      1(2%)
	devils       1(2%)
	lakers       1(2%)
	flyers       1(2%)
	celtic       1(2%)
	raiders      1(2%)
	hornets      1(2%)
	bulls        1(2%)
	indians      1(2%)
	redsox       1(2%)
	hawks        1(2%)



Top 10 swear words passwords are a 1337 version of, or based on:

	64 total.

	pussy       7(10%)
	fuckyou     5(7%)
	sexy        4(6%)
	jerkoff     3(4%)
	playboy     2(3%)
	shit        2(3%)
	ass         2(3%)
	fuck        2(3%)
	bigtits     2(3%)
	panties     2(3%)



100 Interesting Username/Password combos identified:

	1 total.

	bibigon:admin333     1(100%)



Special Characters Seen:

	156 total.

	_     42(26%)
	.     36(23%)
	-     20(12%)
	@     18(11%)
	*     9(5%)
	!     7(4%)
	?     7(4%)
	#     5(3%)
	$     4(2%)
	&     2(1%)
	%     1(0%)
	`     1(0%)
	(     1(0%)
	~     1(0%)
	=     1(0%)
	;     1(0%)



Number of digits per password:
	0	4778(47%)
	1	907(9%)
	2	990(9%)
	3	587(5%)
	4	751(7%)
	5	215(2%)
	6	759(7%)
	7	183(1%)
	8	634(6%)
	9	61(0%)
	10	95(0%)
	11	40(0%)



Users with the same username/password (3%)

	370 total.

	biaka:biaka                             1(0%)
	bibliothecal:bibliothecal               1(0%)
	bhchan:bhchan                           1(0%)
	bherrick:bherrick                       1(0%)
	bhilali:bhilali                         1(0%)
	bicolor:bicolor                         1(0%)
	biconditionals:biconditionals           1(0%)
	bicl:bicl                               1(0%)
	bibliophily:bibliophily                 1(0%)
	bharals:bharals                         1(0%)
	bibounet:bibounet                       1(0%)
	bhangs:bhangs                           1(0%)
	bicarbonates:bicarbonates               1(0%)
	bibausi:bibausi                         1(0%)
	biblicists:biblicists                   1(0%)
	bheisler:bheisler                       1(0%)
	
  (snipped)

Users with the a password which is a 1337/variation of their username (1%)

	174 total.

	bhabes_262004:bhabes               1(0%)
	bhanutak2003:bhanutak              1(0%)
	bhansen2:bhansen                   1(0%)
	bhbirf2:bhbirf                     1(0%)
	biblult:biblult2010                1(0%)
	bianka28:bianka                    1(0%)
	bhtyfvbitkm2:bhtyfvbitkm           1(0%)
	bibendum2006:bibendum              1(0%)
	biatch:Biatch                      1(0%)
	bibi500:bibi501                    1(0%)
	bhs363:bhs1                        1(0%)
	bhight:bhight7                     1(0%)
	biboul27:biboul                    1(0%)
	bhop69:bhop                        1(0%)
	bhira:bhira123                     1(0%)
  
  	(snipped)

	Do you wish to check stats against a password policy? Nb. this adheres to the windows password policy format, where string have three of 	the 4 with regards to complexity, upper, lower, and numeric (yes/no)
	Enter minimum password length:
	Require uppercase? (yes/no)
	Do want to specify how many uppercase characters? (yes/no)
	Enforce numeric characters? (yes/no)
	Do want to specify how many numeric characters? (yes/no)
	Enforce complexity? (yes/no)
	Do want to specify how many special characters? (yes/no)



	bh0307:born2
	bh0307:born28
	bh03180:mandinga
	bh0320:bigblock
	BH0422:761480
	bh0464:0464bh
	bh051993:4sa7ya
	bh051993:hercules
	bh051993:hercules99
	bh051993_639:hercules
	bh051993_784:hercules
	bh0593:4sa7ya
	bh0717:bdpowell
	bh0717:jfleet
	bh0763:ok1650
	bh09:md2020
	bh09319:stud18
	bh0f:r1o6j
	bh0mcp6x:gmqb5oj
	bh0w8d63:standby
	bh1:davesash
	bh100man:arntim3
	bh101074:bt061193
	bh-1022:133010
	bh1024:lyfiehin
	bh1035:123456
	BH1101:whoop02
	bh11155:bertharv54
	bh1116:adventu99
	bh1116:chibears
	bh1116:crimson
	bh1175:robby
	bh119jl:123456
	bh119jl:bh119jl
	bh12084:prelude
	bh121:purpl
	bh1224:fairview
	bh1229:1229bh
	bh1234:1234 (too short - 4 characters)

	(massively snipped, as there was obviously no password policy)    
