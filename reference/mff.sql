-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Sep 06, 2018 at 11:22 AM
-- Server version: 5.5.57-0ubuntu0.14.04.1
-- PHP Version: 5.5.9-1ubuntu4.21

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `HPDT`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbl_admin`
--

CREATE TABLE `tbl_admin` (
  `AdminID` int(11) NOT NULL,
  `AdminLevelID` int(11) NOT NULL,
  `AdminName` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `LoginName` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `Password` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `salt` text COLLATE utf8_unicode_ci NOT NULL,
  `ImagePath` varchar(100) COLLATE utf8_unicode_ci DEFAULT NULL,
  `login_fail_count` int(11) NOT NULL,
  `access_status` tinyint(2) NOT NULL COMMENT '0 - access allow, 1 - Inactive, 2 - Blocked',
  `Email` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `created_date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `modified_date` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci ROW_FORMAT=COMPACT;

--
-- Dumping data for table `tbl_admin`
--

INSERT INTO `tbl_admin` (`AdminID`, `AdminLevelID`, `AdminName`, `LoginName`, `Password`, `salt`, `ImagePath`, `login_fail_count`, `access_status`, `Email`, `created_date`, `modified_date`) VALUES
(1, 1, 'Admin', 'admin', 'wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt', '/SApKtKXpIa6YnHCjKLxQJAeb279BlX8', '1.jpg', 0, 0, 'thandalay@gmail.com', '2018-02-08 09:52:25', '2017-11-07 03:38:35'),
(2, 1, 'soe', 'soe', 'VuN5CHtkjIrocw2oRl5t+/1K1iPdphD7', 'B4IIpsYC82YoSHSw7uTVRY7O37qemggE', '2.jpg', 0, 0, 'naziqueen@gmail.com', '2018-07-30 06:17:58', '2018-07-30 06:17:58'),
(3, 3, 'pont', 'pont', 'x8QL8hLc4jqHCWL86+WNrkU5MueKTR43', 'buFS/sF8RnTGwvu2lP/EQgAw2nuciX1q', '3.jpg', 2, 0, 'naziqueen592@gmail.com', '2018-08-08 03:02:15', '2018-08-08 03:02:15'),
(5, 1, 'Aung Aung', 'aung', 'Tt6liIYI3NS9sZd9sx7ei0jWNXoP5iWr', '7rFynOyZJJ6xM5FXiIVe0w/mbILayCHG', '5.jpg', 0, 0, 'aung@gmail.com', '2018-08-15 07:15:35', '2018-08-15 07:15:35'),
(6, 4, 'popo', 'popo2', 'ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ', '6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF', '6.jpg', 0, 0, 'soepapaoo22@gmail.com', '2018-08-28 03:07:47', '2018-08-28 03:07:47');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_adminlevel`
--

CREATE TABLE `tbl_adminlevel` (
  `AdminLevelID` int(11) NOT NULL,
  `AdminLevel` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `restricted_iplist` text COLLATE utf8_unicode_ci NOT NULL,
  `Description` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `Remark` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `IsAdministrator` tinyint(1) NOT NULL DEFAULT '0',
  `created_date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `modified_date` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci ROW_FORMAT=COMPACT;

--
-- Dumping data for table `tbl_adminlevel`
--

INSERT INTO `tbl_adminlevel` (`AdminLevelID`, `AdminLevel`, `restricted_iplist`, `Description`, `Remark`, `IsAdministrator`, `created_date`, `modified_date`) VALUES
(1, 'Administrator', '', 'Admin', 'can access all function', 1, '0000-00-00 00:00:00', '2018-08-01 06:39:34'),
(2, 'papa', '', '', '', 0, '2018-08-01 06:39:55', '2018-08-27 10:34:09'),
(3, 'pont', '', 'aa', 'aa', 0, '2018-08-27 10:39:29', '2018-09-04 07:05:40'),
(4, 'user', '', 'a', '', 0, '2018-08-29 06:54:25', '2018-08-29 08:13:33');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_adminlevelmenu`
--

CREATE TABLE `tbl_adminlevelmenu` (
  `AdminLevelID` int(11) NOT NULL,
  `AdminMenuID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `tbl_adminlevelmenu`
--

INSERT INTO `tbl_adminlevelmenu` (`AdminLevelID`, `AdminMenuID`) VALUES
(1, 13),
(1, 1),
(1, 6),
(1, 7),
(1, 8),
(1, 5),
(1, 9),
(1, 10),
(1, 11),
(1, 4),
(1, 2),
(1, 45),
(1, 47),
(1, 46),
(1, 68),
(1, 48),
(1, 70),
(1, 40),
(1, 12),
(1, 69),
(1, 0),
(2, 69),
(2, 2),
(2, 0),
(4, 47),
(4, 2),
(4, 45),
(4, 0),
(3, 72),
(3, 2),
(3, 69),
(3, 0);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_adminmenu`
--

CREATE TABLE `tbl_adminmenu` (
  `AdminMenuID` int(11) NOT NULL,
  `ParentID` int(11) NOT NULL,
  `AdminMenuName` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `SrNo` int(11) NOT NULL,
  `ControllerName` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `Icon` varchar(50) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci ROW_FORMAT=COMPACT;

--
-- Dumping data for table `tbl_adminmenu`
--

INSERT INTO `tbl_adminmenu` (`AdminMenuID`, `ParentID`, `AdminMenuName`, `SrNo`, `ControllerName`, `Icon`) VALUES
(1, 0, 'Admin Management', 1, '#', 'glyphicon glyphicon-user icon text-info-lter'),
(2, 0, 'Setup', 2, '#', 'glyphicon glyphicon-cog icon text-info-lter'),
(4, 1, 'Admin Level', 101, 'apps.adminlevel', ''),
(5, 1, 'Admin', 102, 'apps.admin', ''),
(6, 4, 'list', 1001, '#', ''),
(7, 4, 'edit', 1002, '#', ''),
(8, 4, 'delete', 1003, '#', ''),
(9, 5, 'list', 1001, '#', ''),
(10, 5, 'edit', 1002, '#', ''),
(11, 5, 'delete', 1003, '#', ''),
(12, 0, 'Report', 4, '#', 'glyphicons glyphicons-list-alt text-success-lt'),
(13, 12, 'Event Log Report', 101, 'app.eventLogReport', ''),
(40, 0, 'Transaction', 3, '#', 'glyphicons glyphicons-adjust-alt text-success-lt'),
(45, 2, 'General Setup', 101, 'app.general', ''),
(46, 2, 'Setting Setup', 104, 'app.setting', ''),
(47, 45, 'edit', 1002, '#', ''),
(48, 46, 'edit', 1002, '#', ''),
(68, 46, 'list', 1001, '#', ''),
(69, 2, 'Player Setup', 101, 'app.player', ''),
(70, 69, 'edit', 1002, 'app.editPlayer', ''),
(71, 2, 'Club Setup', 102, 'app.club', ''),
(72, 69, 'list', 1001, '#', ''),
(73, 69, 'delete', 1003, '#', ''),
(74, 45, 'list', 1001, '#', ''),
(75, 45, 'delete', 1003, '#', ''),
(77, 40, 'Tournament/Academy', 101, 'app.tournament', '');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_adminmenudetails`
--

CREATE TABLE `tbl_adminmenudetails` (
  `MenuID` int(11) NOT NULL,
  `ControllerName` varchar(50) CHARACTER SET utf8 NOT NULL DEFAULT ''
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `tbl_adminmenudetails`
--

INSERT INTO `tbl_adminmenudetails` (`MenuID`, `ControllerName`) VALUES
(38, 'app.giftcardtype/[0-9]+'),
(10, 'apps.admin/editAdmin'),
(69, 'app.editPlayer/[0-9]+'),
(47, 'app.editGeneral/[0-9]+'),
(69, 'app.player[0-9]+');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_adminmenuurl`
--

CREATE TABLE `tbl_adminmenuurl` (
  `AdminMenuID` int(11) NOT NULL,
  `ServiceUrl` varchar(200) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `tbl_adminmenuurl`
--

INSERT INTO `tbl_adminmenuurl` (`AdminMenuID`, `ServiceUrl`) VALUES
(4, 'adminlevel/GetAdminLevel'),
(4, 'adminlevel/GetAdminLevelMenu'),
(7, 'adminlevel/AddAdminLevel'),
(7, 'adminlevel/AddAdminLevelMenu'),
(8, 'adminlevel/DeleteAdminLevel'),
(5, 'admin/GetAdminSetup'),
(11, 'admin/DeleteAdminSetup'),
(10, 'admin/AddAdminSetup'),
(10, 'admin/SaveImagePath'),
(9, 'admin/GetAdminSetup'),
(10, 'admin/GetAdminSetup'),
(45, 'general/GetGeneralTypeComboData'),
(45, 'general/GetGeneralType'),
(47, 'general/AddGeneral'),
(13, 'eventLog/GetEventLog'),
(6, 'adminlevel/GetAdminLevel'),
(6, 'adminlevel/GetAdminLevelMenu'),
(69, 'player/GetPlayerSetup'),
(70, 'player/AddPlayer'),
(73, 'player/DeletePlayerSetup'),
(70, 'player/GetPositionComboData'),
(70, 'player/GetPlayerCategoryComboData'),
(70, 'player/GetNationalityComboData'),
(70, 'player/GetImageFile'),
(70, 'player/GetFilePath'),
(70, 'player/GetPlayer'),
(70, 'player/SaveImagePath'),
(70, 'player/SaveFileName'),
(69, 'player/ImportFile');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_club`
--

CREATE TABLE `tbl_club` (
  `clubid` bigint(20) NOT NULL,
  `clubname` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `team_manager` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `phone` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `email` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `address` text COLLATE utf8_unicode_ci NOT NULL,
  `logo` text COLLATE utf8_unicode_ci NOT NULL,
  `createdate` datetime NOT NULL,
  `createuser` bigint(20) NOT NULL,
  `isactive` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `tbl_club`
--

INSERT INTO `tbl_club` (`clubid`, `clubname`, `team_manager`, `phone`, `email`, `address`, `logo`, `createdate`, `createuser`, `isactive`) VALUES
(1, 'YGNU', 'U Mg Mg', '09364635', 'mgmg@gmail.com', 'yangon', '', '2018-08-07 00:00:00', 1, 1),
(2, 'AYAU', 'U Kyaw Kyaw ', '083473648', 'kyaw@gmail.com', 'Manaday', '', '2018-08-07 00:00:00', 1, 1),
(3, 'Zwe Gabin', 'U aung aung', '09838732', 'aung@gmail.com', 'yangon', '', '2018-08-13 17:06:44', 1, 1),
(4, 'Shan United', 'U Htay', '09838732443', 'htay@gmail.com', 'yangon', '', '2018-08-13 17:09:41', 1, 0),
(5, 'Yangon United', 'U San ', '03848322', 'san@gmail.com', 'Yangon', '', '2018-08-13 17:12:44', 1, 1),
(6, 'Bago United', 'Thura', '0934832932', 'thura@gmail.com', 'Bago', '', '2018-08-13 17:15:28', 1, 1),
(7, 'Chin United', 'Kyaw Kyaw', '093473923', 'kk@gmail.com', 'Chin', '', '2018-08-13 17:18:42', 1, 0),
(9, 'Yadanrpone', 'U Chit', '09348374', 'cc@gmail.com', 'Mandalay', '9.png', '2018-08-14 10:12:27', 1, 1),
(10, 'Sagaing FC', 'U Mg Mg', '096364445', 'mm@gmail.com', 'Sagaing', '10.png', '2018-08-14 10:21:43', 1, 0),
(11, 'UMM', 'kyaw', '0937473434', 'mmm@gmail.com', 'yangon', '11.png', '2018-08-14 15:06:49', 1, 1),
(21, '', '', '', '', '', '', '2018-08-21 16:56:42', 1, 0),
(22, 'MMA', 'Myo Myo', '09348344', 'gg@gmail.com', 'Yangon', '', '2018-08-23 09:37:21', 1, 1),
(23, 'MGU', 'U ko ko', '03949834', 'hla@gmail.com', 'Magwe', '23.png', '2018-08-23 11:15:40', 1, 1),
(24, 'SSW', 'U Htet', '09987662', 'htet@gmail.com', 'Nay Pyi Taw', '24.png', '2018-09-05 14:48:54', 1, 1);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_club_attachment`
--

CREATE TABLE `tbl_club_attachment` (
  `attachid` bigint(20) NOT NULL,
  `clubid` bigint(20) NOT NULL,
  `attachfilename` text COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `tbl_club_attachment`
--

INSERT INTO `tbl_club_attachment` (`attachid`, `clubid`, `attachfilename`) VALUES
(10, 23, '10.pdf'),
(12, 24, '12.pdf');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_email_template`
--

CREATE TABLE `tbl_email_template` (
  `EmailTemplateID` int(10) UNSIGNED NOT NULL,
  `template_name` varchar(100) COLLATE utf8_unicode_ci DEFAULT NULL,
  `template_content` text COLLATE utf8_unicode_ci,
  `subject` varchar(100) COLLATE utf8_unicode_ci DEFAULT NULL,
  `from_email` varchar(100) COLLATE utf8_unicode_ci DEFAULT NULL,
  `variable` varchar(200) COLLATE utf8_unicode_ci NOT NULL,
  `modified_date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `tbl_email_template`
--

INSERT INTO `tbl_email_template` (`EmailTemplateID`, `template_name`, `template_content`, `subject`, `from_email`, `variable`, `modified_date`) VALUES
(1, 'Account Lock Notification', 'Dear [Account Name],\r\n\r\nWe Found you are trying many times with account name: [Login Name]  and wrong password. So we lock your account.\r\nIf you want to unlock your account, click <a href=\"[Unlock URL]\">here</a>.\r\n\r\nSincerely,\r\nOMDG', 'Account Lock Notification', 'tech@omdg.biz', '[Account Name],[Login Name],[Admin Email]', '2017-09-06 08:02:37'),
(2, 'Forgot Password Notification', 'Dear [Account Name],\r\n\r\nYou have requested that a new password be sent to your email address at [Account Email].\r\n\r\nTo confirm reset password click <a href=\"[Reset URL]\">here</a>\r\n\r\nNew Password: [Generate Password] \r\n\r\nSincerely,\r\nOMDG', 'Forgot Password Notification', 'cardmanagementmm2018@gmail.com', '[Account Name],[Account Email],[Reset URL],[Generate Password]', '2018-06-13 03:00:11'),
(3, 'Contact Email', 'Dear Admin,\n\n[Message]\n\nSincerely,\n[Name]\n[Email]', 'Quick Contact Email', 'tech@omdg.biz', '[Name],[Email],[Message]', '2017-11-09 06:52:48');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_eventlog`
--

CREATE TABLE `tbl_eventlog` (
  `ID` bigint(20) NOT NULL,
  `LogType` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `LogDateTime` datetime NOT NULL,
  `Source` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `LogMessage` text COLLATE utf8_unicode_ci NOT NULL,
  `UserID` int(11) NOT NULL,
  `UserType` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `ipAddress` varchar(20) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `tbl_eventlog`
--

INSERT INTO `tbl_eventlog` (`ID`, `LogType`, `LogDateTime`, `Source`, `LogMessage`, `UserID`, `UserType`, `ipAddress`) VALUES
(1, 'Info', '2018-07-30 10:55:38', 'Admin Login', 'Login Success\r\nGiven data are as follow:\r\nLoginName = \'admin\'\r\nAdminID = \'1\'', 1, 'admin', '::1'),
(2, 'Info', '2018-07-30 11:01:29', 'Admin Login', 'Login Success\r\nGiven data are as follow:\r\nLoginName = \'admin\'\r\nAdminID = \'1\'', 1, 'admin', '::1'),
(3, 'Info', '2018-07-30 11:05:49', 'Admin Login', 'Login Success\r\nGiven data are as follow:\r\nLoginName = \'admin\'\r\nAdminID = \'1\'', 1, 'admin', '::1'),
(4, 'Info', '2018-07-30 11:17:11', 'Add General', '11: Hlegu is created.\r\nNew data are as follow:\r\nid: 11\r\nname: Hlegu\r\ntype: Township\r\nisactive: True', 1, 'admin', '::1'),
(5, 'Info', '2018-07-30 11:24:11', 'Add General', '12: Kayar is created.\r\nNew data are as follow:\r\nid: 12\r\nname: Kayar\r\ntype: Nationality\r\nisactive: True', 1, 'admin', '::1'),
(6, 'Info', '2018-07-30 11:24:33', 'Update General', '12: Kayar is updated.\r\nOld data are as follow:\r\nid: 12\r\nname: Kayar\r\ntype: Nationality\r\nisactive: True', 1, 'admin', '::1'),
(7, 'Info', '2018-07-30 11:25:22', 'Update Admin', '1: Admin is updated.\r\nOld data are as follow:\r\nAdminID: 1\r\nAdminLevelID: 1\r\nAdminName: Admin\r\nLoginName: admin\r\nPassword: wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nsalt: /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\nImagePath: 1.png\r\nlogin_fail_count: 0\r\naccess_status: 0\r\nEmail: thandalay@gmail.com\r\ncreated_date: 2/8/2018 4:22:25 PM\r\nmodified_date: 11/7/2017 10:08:35 AM', 1, 'admin', '::1'),
(8, 'Info', '2018-07-30 12:04:56', 'Admin Login', 'Login Success\r\nGiven data are as follow:\r\nLoginName = \'admin\'\r\nAdminID = \'1\'', 1, 'admin', '::1'),
(9, 'Info', '2018-07-30 12:07:27', 'Admin Login', 'Login Success\r\nGiven data are as follow:\r\nLoginName = \'admin\'\r\nAdminID = \'1\'', 1, 'admin', '::1'),
(10, 'Info', '2018-07-30 12:48:02', 'Add Admin', '2: soe is created.\r\nNew data are as follow:\r\nAdminID: 2\r\nAdminLevelID: 1\r\nAdminName: soe\r\nLoginName: soe\r\nPassword: +10ei2B4t1xIKSXGUHVCZ0Nz5d5xw7Ng\r\nsalt: B4IIpsYC82YoSHSw7uTVRY7O37qemggE\r\nImagePath: \r\nlogin_fail_count: 0\r\naccess_status: 0\r\nEmail: naziqueen@gmail.com\r\ncreated_date: 7/30/2018 12:47:58 PM\r\nmodified_date: 7/30/2018 12:47:58 PM', 1, 'admin', '::1'),
(11, 'Info', '2018-07-30 12:48:47', 'Admin Login', 'Login Success\r\nGiven data are as follow:\r\nLoginName = \'soe\'\r\nAdminID = \'2\'', 2, 'admin', '::1'),
(12, 'Info', '2018-07-30 12:49:30', 'Admin Change Password', 'Change Password\r\nGiven data are as follow:\r\nAdminID = \'2\'', 2, 'admin', '::1'),
(13, 'Info', '2018-07-30 12:49:52', 'Admin Login', 'Login Success\r\nGiven data are as follow:\r\nLoginName = \'soe\'\r\nAdminID = \'2\'', 2, 'admin', '::1'),
(14, 'Info', '2018-07-30 12:50:27', 'Admin Login', 'Login Success\r\nGiven data are as follow:\r\nLoginName = \'admin\'\r\nAdminID = \'1\'', 1, 'admin', '::1'),
(15, 'Info', '2018-07-30 13:00:27', 'Admin Login', 'Login Success\r\nGiven data are as follow:\r\nLoginName = \'admin\'\r\nAdminID = \'1\'', 1, 'admin', '::1'),
(16, 'Info', '2018-07-30 14:11:57', 'Admin Login', 'Login Success\r\nGiven data are as follow:\r\nLoginName = \'admin\'\r\nAdminID = \'1\'', 1, 'admin', '::1'),
(17, 'Info', '2018-07-30 14:12:56', 'Update Admin', '1: Admin is updated.\r\nOld data are as follow:\r\nAdminID: 1\r\nAdminLevelID: 1\r\nAdminName: Admin\r\nLoginName: admin\r\nPassword: wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nsalt: /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\nImagePath: 1.png\r\nlogin_fail_count: 0\r\naccess_status: 0\r\nEmail: thandalay@gmail.com\r\ncreated_date: 2/8/2018 4:22:25 PM\r\nmodified_date: 11/7/2017 10:08:35 AM', 1, 'admin', '::1'),
(18, 'Info', '2018-07-30 14:18:59', 'Admin Login', 'Login Success\r\nGiven data are as follow:\r\nLoginName = \'admin\'\r\nAdminID = \'1\'', 1, 'admin', '::1'),
(19, 'Info', '2018-07-30 16:46:32', 'Admin Login', 'Login Success\r\nGiven data are as follow:\r\nLoginName = \'admin\'\r\nAdminID = \'1\'', 1, 'admin', '::1'),
(20, 'Info', '2018-07-30 16:55:08', 'Add Player', '2: 2 is created.\r\nNew data are as follow:\r\nplayerid: 2\r\nenroll_number: 002\r\nHPDTid: jj\r\nplayer_name: Kyaw Kyaw\r\ngender: 1\r\naddress: Yangon\r\nnrc: 1234556\r\npassport: 1234\r\nafcid: hh\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 7\r\nsecondary_player_category: 8\r\ndateofbirth: 2/13/1996 12:00:00 AM\r\nphoto: \r\nisactive: 1\r\ncreatedate: 7/30/2018 4:54:36 PM\r\ncreateuser: 1', 1, 'admin', '::1'),
(21, 'Info', '2018-07-30 17:02:19', 'Add Player', '4: 4 is created.\r\nNew data are as follow:\r\nplayerid: 4\r\nenroll_number: 002\r\nHPDTid: jj\r\nplayer_name: Kyaw Kyaw\r\ngender: 1\r\naddress: Yangon\r\nnrc: 1234556\r\npassport: 1234\r\nafcid: hh\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 7\r\nsecondary_player_category: 8\r\ndateofbirth: 2/13/1996 12:00:00 AM\r\nphoto: \r\nisactive: 1\r\ncreatedate: 7/30/2018 5:01:59 PM\r\ncreateuser: 1', 1, 'admin', '::1'),
(22, 'Info', '2018-07-31 12:00:36', 'Add Admin Level', '2: papa is created.\r\nNew data are as follow:\r\nAdminLevelID: 2\r\nAdminLevel: papa\r\nrestricted_iplist: \r\nDescription: \r\nRemark: \r\nIsAdministrator: False\r\ncreated_date: 7/31/2018 12:00:33 PM\r\nmodified_date: 7/31/2018 12:00:33 PM', 1, 'admin', '127.0.0.1'),
(23, 'Info', '2018-07-31 12:00:41', 'Add Admin Level Menu', '2 is created.\r\nNew data are as follow:\r\nAdminLevelID: 2\r\nAdminMenuID: 0\r\nAdminLevelID: 2\r\nAdminMenuID: 40\r\nAdminLevelID: 2\r\nAdminMenuID: 48\r\nAdminLevelID: 2\r\nAdminMenuID: 68\r\nAdminLevelID: 2\r\nAdminMenuID: 46\r\nAdminLevelID: 2\r\nAdminMenuID: 69\r\nAdminLevelID: 2\r\nAdminMenuID: 47\r\nAdminLevelID: 2\r\nAdminMenuID: 2\r\nAdminLevelID: 2\r\nAdminMenuID: 45\r\nAdminLevelID: 2\r\nAdminMenuID: 11\r\nAdminLevelID: 2\r\nAdminMenuID: 10\r\nAdminLevelID: 2\r\nAdminMenuID: 9\r\nAdminLevelID: 2\r\nAdminMenuID: 5\r\nAdminLevelID: 2\r\nAdminMenuID: 8\r\nAdminLevelID: 2\r\nAdminMenuID: 7\r\nAdminLevelID: 2\r\nAdminMenuID: 6\r\nAdminLevelID: 2\r\nAdminMenuID: 1\r\nAdminLevelID: 2\r\nAdminMenuID: 4\r\nAdminLevelID: 2\r\nAdminMenuID: 12\r\nAdminLevelID: 2\r\nAdminMenuID: 13', 1, 'admin', '127.0.0.1'),
(24, 'Info', '2018-07-31 12:01:19', 'Delete Admin Level', '2 is deleted.\r\nOld data are as follow:\r\nAdminLevelID: 2\r\nAdminLevel: papa\r\nrestricted_iplist: \r\nDescription: \r\nRemark: \r\nIsAdministrator: False\r\ncreated_date: 7/31/2018 12:00:33 PM\r\nmodified_date: 7/31/2018 12:00:33 PM', 1, 'admin', '127.0.0.1'),
(25, 'Info', '2018-07-31 13:03:51', 'Admin Reset Password', 'Reset Password\r\nGiven data are as follow:\r\nAdminID = \'2\'', 1, 'admin', '127.0.0.1'),
(26, 'Info', '2018-07-31 13:03:55', 'Admin Reset Password', 'Reset Password\r\nGiven data are as follow:\r\nAdminID = \'2\'', 1, 'admin', '127.0.0.1'),
(27, 'Info', '2018-07-31 13:04:00', 'Admin Reset Password', 'Reset Password\r\nGiven data are as follow:\r\nAdminID = \'2\'', 1, 'admin', '127.0.0.1'),
(28, 'Info', '2018-07-31 13:04:04', 'Admin Reset Password', 'Reset Password\r\nGiven data are as follow:\r\nAdminID = \'2\'', 1, 'admin', '127.0.0.1'),
(29, 'Info', '2018-07-31 13:04:08', 'Admin Reset Password', 'Reset Password\r\nGiven data are as follow:\r\nAdminID = \'2\'', 1, 'admin', '127.0.0.1'),
(30, 'Info', '2018-07-31 13:04:12', 'Admin Reset Password', 'Reset Password\r\nGiven data are as follow:\r\nAdminID = \'2\'', 1, 'admin', '127.0.0.1'),
(31, 'Info', '2018-08-01 13:08:17', 'Update Admin Level', '1: papa is updated.\r\nOld data are as follow:\r\nAdminLevelID: 1\r\nAdminLevel: Administrator\r\nrestricted_iplist: \r\nDescription: Admin\r\nRemark: can access all function\r\nIsAdministrator: True\r\ncreated_date: 1/1/0001 12:00:00 AM\r\nmodified_date: 1/19/2018 11:42:47 AM', 1, 'admin', '127.0.0.1'),
(32, 'Info', '2018-08-01 13:08:22', 'Add Admin Level Menu', '1 is created.\r\nNew data are as follow:\r\nAdminLevelID: 1\r\nAdminMenuID: 0\r\nAdminLevelID: 1\r\nAdminMenuID: 40\r\nAdminLevelID: 1\r\nAdminMenuID: 70\r\nAdminLevelID: 1\r\nAdminMenuID: 48\r\nAdminLevelID: 1\r\nAdminMenuID: 68\r\nAdminLevelID: 1\r\nAdminMenuID: 46\r\nAdminLevelID: 1\r\nAdminMenuID: 47\r\nAdminLevelID: 1\r\nAdminMenuID: 45\r\nAdminLevelID: 1\r\nAdminMenuID: 69\r\nAdminLevelID: 1\r\nAdminMenuID: 12\r\nAdminLevelID: 1\r\nAdminMenuID: 2\r\nAdminLevelID: 1\r\nAdminMenuID: 10\r\nAdminLevelID: 1\r\nAdminMenuID: 9\r\nAdminLevelID: 1\r\nAdminMenuID: 5\r\nAdminLevelID: 1\r\nAdminMenuID: 8\r\nAdminLevelID: 1\r\nAdminMenuID: 7\r\nAdminLevelID: 1\r\nAdminMenuID: 6\r\nAdminLevelID: 1\r\nAdminMenuID: 1\r\nAdminLevelID: 1\r\nAdminMenuID: 4\r\nAdminLevelID: 1\r\nAdminMenuID: 11\r\nAdminLevelID: 1\r\nAdminMenuID: 13', 1, 'admin', '127.0.0.1'),
(33, 'Info', '2018-08-01 13:09:35', 'Update Admin Level', '1: Administrator is updated.\r\nOld data are as follow:\r\nAdminLevelID: 1\r\nAdminLevel: papa\r\nrestricted_iplist: \r\nDescription: Admin\r\nRemark: can access all function\r\nIsAdministrator: True\r\ncreated_date: 1/1/0001 12:00:00 AM\r\nmodified_date: 8/1/2018 1:08:16 PM', 1, 'admin', '127.0.0.1'),
(34, 'Info', '2018-08-01 13:09:41', 'Add Admin Level Menu', '1 is created.\r\nNew data are as follow:\r\nAdminLevelID: 1\r\nAdminMenuID: 13\r\nAdminLevelID: 1\r\nAdminMenuID: 1\r\nAdminLevelID: 1\r\nAdminMenuID: 6\r\nAdminLevelID: 1\r\nAdminMenuID: 7\r\nAdminLevelID: 1\r\nAdminMenuID: 8\r\nAdminLevelID: 1\r\nAdminMenuID: 5\r\nAdminLevelID: 1\r\nAdminMenuID: 9\r\nAdminLevelID: 1\r\nAdminMenuID: 10\r\nAdminLevelID: 1\r\nAdminMenuID: 11\r\nAdminLevelID: 1\r\nAdminMenuID: 4\r\nAdminLevelID: 1\r\nAdminMenuID: 2\r\nAdminLevelID: 1\r\nAdminMenuID: 45\r\nAdminLevelID: 1\r\nAdminMenuID: 47\r\nAdminLevelID: 1\r\nAdminMenuID: 46\r\nAdminLevelID: 1\r\nAdminMenuID: 68\r\nAdminLevelID: 1\r\nAdminMenuID: 48\r\nAdminLevelID: 1\r\nAdminMenuID: 70\r\nAdminLevelID: 1\r\nAdminMenuID: 40\r\nAdminLevelID: 1\r\nAdminMenuID: 12\r\nAdminLevelID: 1\r\nAdminMenuID: 69\r\nAdminLevelID: 1\r\nAdminMenuID: 0', 1, 'admin', '127.0.0.1'),
(35, 'Info', '2018-08-01 13:09:57', 'Add Admin Level', '2: papa is created.\r\nNew data are as follow:\r\nAdminLevelID: 2\r\nAdminLevel: papa\r\nrestricted_iplist: \r\nDescription: \r\nRemark: \r\nIsAdministrator: False\r\ncreated_date: 8/1/2018 1:09:55 PM\r\nmodified_date: 8/1/2018 1:09:55 PM', 1, 'admin', '127.0.0.1'),
(36, 'Info', '2018-08-01 13:10:03', 'Add Admin Level Menu', '2 is created.\r\nNew data are as follow:\r\nAdminLevelID: 2\r\nAdminMenuID: 12\r\nAdminLevelID: 2\r\nAdminMenuID: 4\r\nAdminLevelID: 2\r\nAdminMenuID: 1\r\nAdminLevelID: 2\r\nAdminMenuID: 6\r\nAdminLevelID: 2\r\nAdminMenuID: 7\r\nAdminLevelID: 2\r\nAdminMenuID: 8\r\nAdminLevelID: 2\r\nAdminMenuID: 5\r\nAdminLevelID: 2\r\nAdminMenuID: 9\r\nAdminLevelID: 2\r\nAdminMenuID: 10\r\nAdminLevelID: 2\r\nAdminMenuID: 0\r\nAdminLevelID: 2\r\nAdminMenuID: 11\r\nAdminLevelID: 2\r\nAdminMenuID: 69\r\nAdminLevelID: 2\r\nAdminMenuID: 45\r\nAdminLevelID: 2\r\nAdminMenuID: 47\r\nAdminLevelID: 2\r\nAdminMenuID: 46\r\nAdminLevelID: 2\r\nAdminMenuID: 68\r\nAdminLevelID: 2\r\nAdminMenuID: 48\r\nAdminLevelID: 2\r\nAdminMenuID: 70\r\nAdminLevelID: 2\r\nAdminMenuID: 40\r\nAdminLevelID: 2\r\nAdminMenuID: 2\r\nAdminLevelID: 2\r\nAdminMenuID: 13', 1, 'admin', '127.0.0.1'),
(37, 'Info', '2018-08-02 16:58:01', 'Add General', '13: Bago is created.\r\nNew data are as follow:\r\nid: 13\r\nname: Bago\r\ntype: State\r\nisactive: True', 1, 'admin', '127.0.0.1'),
(38, 'Info', '2018-08-02 17:01:14', 'Update General', '1: Yangon is updated.\r\nOld data are as follow:\r\nid: 1\r\nname: Yangon\r\ntype: State\r\nisactive: True', 1, 'admin', '127.0.0.1'),
(39, 'Info', '2018-08-02 17:03:22', 'Update General', '1: Mandalay is updated.\r\nOld data are as follow:\r\nid: 1\r\nname: Mandalay\r\ntype: State\r\nisactive: True', 1, 'admin', '127.0.0.1'),
(40, 'Info', '2018-08-02 17:08:22', 'Update General', '13: Bago is updated.\r\nOld data are as follow:\r\nid: 13\r\nname: Bago\r\ntype: State\r\nisactive: True', 1, 'admin', '127.0.0.1'),
(41, 'Info', '2018-08-02 17:09:12', 'Update General', '13: NayPyiTaw is updated.\r\nOld data are as follow:\r\nid: 13\r\nname: NayPyiTaw\r\ntype: State\r\nisactive: True', 1, 'admin', '127.0.0.1'),
(42, 'Info', '2018-08-02 17:10:06', 'Add General', '14: Mandalay is created.\r\nNew data are as follow:\r\nid: 14\r\nname: Mandalay\r\ntype: State\r\nisactive: True', 1, 'admin', '127.0.0.1'),
(43, 'Info', '2018-08-02 17:13:40', 'Add General', '15: Pyay is created.\r\nNew data are as follow:\r\nid: 15\r\nname: Pyay\r\ntype: State\r\nisactive: True', 1, 'admin', '127.0.0.1'),
(44, 'Info', '2018-08-02 17:15:22', 'Add General', '16: InSein is created.\r\nNew data are as follow:\r\nid: 16\r\nname: InSein\r\ntype: Township\r\nisactive: True', 1, 'admin', '127.0.0.1'),
(45, 'Info', '2018-08-02 17:20:42', 'Update General', '10: Wormen FootBall is updated.\r\nOld data are as follow:\r\nid: 10\r\nname: Wormen FootBall\r\ntype: Player Category\r\nisactive: True', 1, 'admin', '127.0.0.1'),
(46, 'Info', '2018-08-02 17:35:15', 'Update Counter', '15: Pyay is deleted.\r\nOld data are as follow:\r\nid: 15\r\nname: Pyay\r\ntype: State\r\nisactive: True', 1, 'admin', '127.0.0.1'),
(47, 'Info', '2018-08-02 17:38:28', 'Update Counter', '13: Bago is deleted.\r\nOld data are as follow:\r\nid: 13\r\nname: Bago\r\ntype: State\r\nisactive: True', 1, 'admin', '127.0.0.1'),
(48, 'Info', '2018-08-03 09:17:39', 'Add General', '17: Bago is created.\r\nNew data are as follow:\r\nid: 17\r\nname: Bago\r\ntype: State\r\nisactive: True', 1, 'admin', '127.0.0.1'),
(49, 'Info', '2018-08-03 09:18:00', 'Update Counter', '17: Bago is deleted.\r\nOld data are as follow:\r\nid: 17\r\nname: Bago\r\ntype: State\r\nisactive: True', 1, 'admin', '127.0.0.1'),
(50, 'Info', '2018-08-03 09:18:16', 'Add General', '18: Bago is created.\r\nNew data are as follow:\r\nid: 18\r\nname: Bago\r\ntype: State\r\nisactive: True', 1, 'admin', '127.0.0.1'),
(51, 'Info', '2018-08-03 11:53:15', 'Add Player', '5: 5 is created.\r\nNew data are as follow:\r\nplayerid: 5\r\nenroll_number: 0007\r\nHPDTid: 233\r\nplayer_name: aung aung\r\ngender: 1\r\naddress: y\r\nnrc: 54546567\r\npassport: 666668\r\nafcid: 300\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 8\r\nsecondary_player_category: 8\r\ndateofbirth: 2/5/2000 12:00:00 AM\r\nphoto:  \r\nisactive: 1\r\ncreatedate: 8/3/2018 11:53:02 AM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(52, 'Info', '2018-08-03 12:00:14', 'Add Player', '6: 6 is created.\r\nNew data are as follow:\r\nplayerid: 6\r\nenroll_number: 00055\r\nHPDTid: 2222\r\nplayer_name: Aye Aye\r\ngender: 0\r\naddress: Yangon\r\nnrc: 454545\r\npassport: 34343\r\nafcid: 3330\r\nposition: 3\r\nnationality: 12\r\nprimary_player_category: 9\r\nsecondary_player_category: 9\r\ndateofbirth: 9/8/1998 12:00:00 AM\r\nphoto:  \r\nisactive: 1\r\ncreatedate: 8/3/2018 12:00:11 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(53, 'Info', '2018-08-03 13:45:40', 'Add Player', '7: 7 is created.\r\nNew data are as follow:\r\nplayerid: 7\r\nenroll_number: 005\r\nHPDTid: 43434\r\nplayer_name: mya mya\r\ngender: 0\r\naddress: mandalay\r\nnrc: 45456\r\npassport: 34356\r\nafcid: 3434\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 9\r\nsecondary_player_category: 9\r\ndateofbirth: 5/21/1998 12:00:00 AM\r\nphoto:  \r\nisactive: 1\r\ncreatedate: 8/3/2018 1:45:37 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(54, 'Info', '2018-08-03 17:15:05', 'Add Player', '8: 8 is created.\r\nNew data are as follow:\r\nplayerid: 8\r\nenroll_number: 0057\r\nHPDTid: 4443\r\nplayer_name: gg\r\ngender: 1\r\naddress: pyY\r\nnrc: 343535\r\npassport: 3434\r\nafcid: 3434\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 7\r\nsecondary_player_category: 7\r\ndateofbirth: 9/7/2009 12:00:00 AM\r\nphoto:  \r\nisactive: 1\r\ncreatedate: 8/3/2018 5:15:02 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(55, 'Info', '2018-08-03 17:26:20', 'Add Player', '9: 9 is created.\r\nNew data are as follow:\r\nplayerid: 9\r\nenroll_number: 989\r\nHPDTid: ghfh\r\nplayer_name: jyjgj\r\ngender: 0\r\naddress: fhhf\r\nnrc: 7878\r\npassport: 7i97\r\nafcid: 7yi\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 7\r\nsecondary_player_category: 7\r\ndateofbirth: 1/16/2012 12:00:00 AM\r\nphoto:  \r\nisactive: 1\r\ncreatedate: 8/3/2018 5:26:17 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(56, 'Info', '2018-08-04 10:26:42', 'Add Player', '10: 10 is created.\r\nNew data are as follow:\r\nplayerid: 10\r\nenroll_number: 00095\r\nHPDTid: 56567\r\nplayer_name: kyu kyu\r\ngender: 0\r\naddress: 556\r\nnrc: 5656\r\npassport: 656564\r\nafcid: 4535\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 10\r\nsecondary_player_category: 10\r\ndateofbirth: 8/11/2010 12:00:00 AM\r\nphoto:  \r\nisactive: 1\r\ncreatedate: 8/4/2018 10:26:38 AM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(57, 'Info', '2018-08-06 09:26:42', 'Add Player', '11: 11 is created.\r\nNew data are as follow:\r\nplayerid: 11\r\nenroll_number: 5678\r\nHPDTid: 2334\r\nplayer_name: juju\r\ngender: 0\r\naddress: mandalay\r\nnrc: 43535\r\npassport: 454545\r\nafcid: 3344\r\nposition: 5\r\nnationality: 4\r\nprimary_player_category: 7\r\nsecondary_player_category: 7\r\ndateofbirth: 1/30/2001 12:00:00 AM\r\nphoto:  \r\nisactive: 1\r\ncreatedate: 8/6/2018 9:26:39 AM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(58, 'Info', '2018-08-06 09:54:02', 'Add Player', '12: 12 is created.\r\nNew data are as follow:\r\nplayerid: 12\r\nenroll_number: 5556\r\nHPDTid: 5656\r\nplayer_name: yuyu\r\ngender: 0\r\naddress: ygn\r\nnrc: 4545\r\npassport: t5455\r\nafcid: 5656\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 8\r\nsecondary_player_category: 8\r\ndateofbirth: 12/9/1998 12:00:00 AM\r\nphoto:  \r\nisactive: 1\r\ncreatedate: 8/6/2018 9:53:59 AM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(59, 'Info', '2018-08-06 11:23:07', 'Add Player', '13: 13 is created.\r\nNew data are as follow:\r\nplayerid: 13\r\nenroll_number: 808\r\nHPDTid: 34\r\nplayer_name: koko\r\ngender: 1\r\naddress: Pyay\r\nnrc: 3434tt\r\npassport: 3434555\r\nafcid: 12\r\nposition: 5\r\nnationality: 4\r\nprimary_player_category: 7\r\nsecondary_player_category: 7\r\ndateofbirth: 3/6/2000 12:00:00 AM\r\nphoto:  \r\nisactive: 1\r\ncreatedate: 8/6/2018 11:23:03 AM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(60, 'Info', '2018-08-06 14:06:11', 'Add Player', '14: 14 is created.\r\nNew data are as follow:\r\nplayerid: 14\r\nenroll_number: 6700\r\nHPDTid: 4545\r\nplayer_name: kuku\r\ngender: 1\r\naddress: yyhn\r\nnrc: 454\r\npassport: 35666\r\nafcid: 4545\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 7\r\nsecondary_player_category: 7\r\ndateofbirth: 12/30/1998 12:00:00 AM\r\nphoto:  \r\nisactive: 1\r\ncreatedate: 8/6/2018 2:06:08 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(61, 'Info', '2018-08-07 10:33:19', 'Delete player', '13 is deleted.\r\nOld data are as follow:\r\nplayerid: 13\r\nenroll_number: 808\r\nHPDTid: 34\r\nplayer_name: koko\r\ngender: 1\r\naddress: Pyay\r\nnrc: 3434tt\r\npassport: 3434555\r\nafcid: 12\r\nposition: 5\r\nnationality: 4\r\nprimary_player_category: 7\r\nsecondary_player_category: 7\r\ndateofbirth: 3/6/2000 12:00:00 AM\r\nphoto:  \r\nisactive: 1\r\ncreatedate: 8/6/2018 11:23:03 AM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(62, 'Info', '2018-08-07 11:34:11', 'Update Player', '12: yuyu is updated.\r\nOld data are as follow:\r\nplayerid: 12\r\nenroll_number: 5556\r\nHPDTid: 5656\r\nplayer_name: yuyu\r\ngender: 0\r\naddress: ygn\r\nnrc: 4545\r\npassport: t5455\r\nafcid: 5656\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 8\r\nsecondary_player_category: 8\r\ndateofbirth: 12/9/1998 12:00:00 AM\r\nphoto: th.jpg\r\nisactive: 1\r\ncreatedate: 8/6/2018 9:53:59 AM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(63, 'Info', '2018-08-07 11:50:32', 'Delete player', '9 is deleted.\r\nOld data are as follow:\r\nplayerid: 9\r\nenroll_number: 989\r\nHPDTid: ghfh\r\nplayer_name: jyjgj\r\ngender: 0\r\naddress: fhhf\r\nnrc: 7878\r\npassport: 7i97\r\nafcid: 7yi\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 7\r\nsecondary_player_category: 7\r\ndateofbirth: 1/16/2012 12:00:00 AM\r\nphoto:  \r\nisactive: 1\r\ncreatedate: 8/3/2018 5:26:17 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(64, 'Info', '2018-08-07 11:54:22', 'Delete player', '4 is deleted.\r\nOld data are as follow:\r\nplayerid: 4\r\nenroll_number: 002\r\nHPDTid: jj\r\nplayer_name: Kyaw Kyaw\r\ngender: 1\r\naddress: Yangon\r\nnrc: 1234556\r\npassport: 1234\r\nafcid: hh\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 7\r\nsecondary_player_category: 8\r\ndateofbirth: 2/13/1996 12:00:00 AM\r\nphoto: \r\nisactive: 1\r\ncreatedate: 7/30/2018 5:01:59 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(65, 'Info', '2018-08-07 12:44:57', 'Update Player', '11: juju is updated.\r\nOld data are as follow:\r\nplayerid: 11\r\nenroll_number: 5678\r\nHPDTid: 2334\r\nplayer_name: juju\r\ngender: 0\r\naddress: mandalay\r\nnrc: 43535\r\npassport: 454545\r\nafcid: 3344\r\nposition: 5\r\nnationality: 4\r\nprimary_player_category: 7\r\nsecondary_player_category: 7\r\ndateofbirth: 1/30/2001 12:00:00 AM\r\nphoto: Wanna-One91.jpg\r\nisactive: 1\r\ncreatedate: 8/6/2018 9:26:39 AM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(66, 'Info', '2018-08-07 12:59:54', 'Add Player', '12: 12 is created.\r\nNew data are as follow:\r\nplayerid: 12\r\nenroll_number: 5556\r\nHPDTid: 5656\r\nplayer_name: Ei Ei\r\ngender: 0\r\naddress: Yangon \r\nnrc: 454546\r\npassport: t5455\r\nafcid: 5656\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 8\r\nsecondary_player_category: 8\r\ndateofbirth: 12/9/1998 12:00:00 AM\r\nphoto: th.jpg\r\nisactive: 1\r\ncreatedate: 8/7/2018 11:34:10 AM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(67, 'Info', '2018-08-07 13:42:09', 'Add Player', '14: 14 is created.\r\nNew data are as follow:\r\nplayerid: 14\r\nenroll_number: 100056\r\nHPDTid: HPDT123\r\nplayer_name: Thiha\r\ngender: 1\r\naddress: Mandalay\r\nnrc: 4667788\r\npassport: 4545\r\nafcid: 4444\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 10\r\nsecondary_player_category: 10\r\ndateofbirth: 5/7/2001 12:00:00 AM\r\nphoto:  \r\nisactive: 1\r\ncreatedate: 8/7/2018 1:42:06 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(68, 'Info', '2018-08-07 13:47:24', 'Add Player', '15: 15 is created.\r\nNew data are as follow:\r\nplayerid: 15\r\nenroll_number: 10089\r\nHPDTid: HPDT456\r\nplayer_name: Thiha\r\ngender: 1\r\naddress: Mandaly\r\nnrc: 3566788\r\npassport: 34346848954\r\nafcid: 3445\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 7\r\nsecondary_player_category: 7\r\ndateofbirth: 11/23/1999 12:00:00 AM\r\nphoto:  \r\nisactive: 1\r\ncreatedate: 8/7/2018 1:47:22 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(69, 'Info', '2018-08-07 13:49:08', 'Add Player', '16: 16 is created.\r\nNew data are as follow:\r\nplayerid: 16\r\nenroll_number: 10089\r\nHPDTid: HPDT456\r\nplayer_name: Thiha\r\ngender: 1\r\naddress: Mandaly\r\nnrc: 3566788\r\npassport: 34346848954\r\nafcid: 3445\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 7\r\nsecondary_player_category: 7\r\ndateofbirth: 11/23/1999 12:00:00 AM\r\nphoto:  \r\nisactive: 1\r\ncreatedate: 8/7/2018 1:49:05 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(70, 'Info', '2018-08-07 13:54:57', 'Add Player', '17: 17 is created.\r\nNew data are as follow:\r\nplayerid: 17\r\nenroll_number: 100010\r\nHPDTid: 34344\r\nplayer_name: Thiha\r\ngender: 1\r\naddress: Yangon\r\nnrc: 344556888\r\npassport: 09983844\r\nafcid: 2323\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 7\r\nsecondary_player_category: 7\r\ndateofbirth: 1/18/2004 12:00:00 AM\r\nphoto:  \r\nisactive: 1\r\ncreatedate: 8/7/2018 1:54:54 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(71, 'Info', '2018-08-07 13:57:17', 'Add Player', '18: 18 is created.\r\nNew data are as follow:\r\nplayerid: 18\r\nenroll_number: 100010\r\nHPDTid: 34344\r\nplayer_name: Thiha\r\ngender: 1\r\naddress: Yangon\r\nnrc: 344556888\r\npassport: 09983844\r\nafcid: 2323\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 7\r\nsecondary_player_category: 7\r\ndateofbirth: 1/18/2004 12:00:00 AM\r\nphoto:  \r\nisactive: 1\r\ncreatedate: 8/7/2018 1:57:15 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(72, 'Info', '2018-08-07 14:06:23', 'Add Player', '19: 19 is created.\r\nNew data are as follow:\r\nplayerid: 19\r\nenroll_number: 00986\r\nHPDTid: HPDT456\r\nplayer_name: Thiha\r\ngender: 1\r\naddress: ygn\r\nnrc: 0972469\r\npassport: 00987654\r\nafcid: 8889\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 8\r\nsecondary_player_category: 8\r\ndateofbirth: 5/13/1998 12:00:00 AM\r\nphoto:  \r\nisactive: 1\r\ncreatedate: 8/7/2018 2:06:20 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(73, 'Info', '2018-08-07 14:24:10', 'Add Player', '20: 20 is created.\r\nNew data are as follow:\r\nplayerid: 20\r\nenroll_number: 00786\r\nHPDTid: HPDT11\r\nplayer_name: Zaw Zaw\r\ngender: 1\r\naddress: Yangon\r\nnrc: 7778899\r\npassport: 34344567\r\nafcid: 233\r\nposition: 5\r\nnationality: 4\r\nprimary_player_category: 8\r\nsecondary_player_category: 8\r\ndateofbirth: 12/2/2001 12:00:00 AM\r\nphoto:  \r\nisactive: 1\r\ncreatedate: 8/7/2018 2:24:08 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(74, 'Info', '2018-08-07 14:34:54', 'Add Player', '21: 21 is created.\r\nNew data are as follow:\r\nplayerid: 21\r\nenroll_number: 50030\r\nHPDTid: HPDT789\r\nplayer_name: Ye Ko\r\ngender: 1\r\naddress: Bago\r\nnrc: 888854\r\npassport: 109832\r\nafcid: 1002\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 8\r\nsecondary_player_category: 8\r\ndateofbirth: 8/27/2001 12:00:00 AM\r\nphoto:  \r\nisactive: 1\r\ncreatedate: 8/7/2018 2:34:51 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(75, 'Info', '2018-08-07 14:43:25', 'Add Player', '22: 22 is created.\r\nNew data are as follow:\r\nplayerid: 22\r\nenroll_number: 4000\r\nHPDTid: HPDT007\r\nplayer_name: Thi Thi\r\ngender: 0\r\naddress: Pyay\r\nnrc: 012345\r\npassport: 000111\r\nafcid: 3455\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 10\r\nsecondary_player_category: 10\r\ndateofbirth: 9/8/1998 12:00:00 AM\r\nphoto:  \r\nisactive: 1\r\ncreatedate: 8/7/2018 2:43:22 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(76, 'Info', '2018-08-07 15:09:10', 'Add Player', '23: 23 is created.\r\nNew data are as follow:\r\nplayerid: 23\r\nenroll_number: 8080\r\nHPDTid: HPDT8765\r\nplayer_name: Htet Lin\r\ngender: 1\r\naddress: Yangon\r\nnrc: 111123\r\npassport: 222233\r\nafcid: 0098\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 7\r\nsecondary_player_category: 7\r\ndateofbirth: 1/13/2004 12:00:00 AM\r\nphoto:  \r\nisactive: 1\r\ncreatedate: 8/7/2018 3:09:07 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(77, 'Info', '2018-08-07 16:29:54', 'Update Player', '23: Htet Lin is updated.\r\nOld data are as follow:\r\nplayerid: 23\r\nenroll_number: 8080\r\nHPDTid: HPDT8765\r\nplayer_name: Htet Lin\r\ngender: 1\r\naddress: Yangon\r\nnrc: 111123\r\npassport: 222233\r\nafcid: 0098\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 7\r\nsecondary_player_category: 7\r\ndateofbirth: 1/13/2004 12:00:00 AM\r\nphoto: 23.jpg\r\nisactive: 1\r\ncreatedate: 8/7/2018 3:09:07 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(78, 'Info', '2018-08-07 16:31:10', 'Add Player', '23: 23 is created.\r\nNew data are as follow:\r\nplayerid: 23\r\nenroll_number: 8080\r\nHPDTid: HPDT8765\r\nplayer_name: Htet Lin\r\ngender: 1\r\naddress: Mandalay\r\nnrc: 111123\r\npassport: 222233\r\nafcid: 0098\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 10\r\nsecondary_player_category: 10\r\ndateofbirth: 1/13/2004 12:00:00 AM\r\nphoto: 23.jpg\r\nisactive: 1\r\ncreatedate: 8/7/2018 4:29:53 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(79, 'Info', '2018-08-07 16:49:30', 'Delete player', '21 is deleted.\r\nOld data are as follow:\r\nplayerid: 21\r\nenroll_number: 50030\r\nHPDTid: HPDT789\r\nplayer_name: Ye Ko\r\ngender: 1\r\naddress: Bago\r\nnrc: 888854\r\npassport: 109832\r\nafcid: 1002\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 8\r\nsecondary_player_category: 8\r\ndateofbirth: 8/27/2001 12:00:00 AM\r\nphoto:  \r\nisactive: 1\r\ncreatedate: 8/7/2018 2:34:51 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(80, 'Info', '2018-08-07 16:49:40', 'Delete player', '20 is deleted.\r\nOld data are as follow:\r\nplayerid: 20\r\nenroll_number: 00786\r\nHPDTid: HPDT11\r\nplayer_name: Zaw Zaw\r\ngender: 1\r\naddress: Yangon\r\nnrc: 7778899\r\npassport: 34344567\r\nafcid: 233\r\nposition: 5\r\nnationality: 4\r\nprimary_player_category: 8\r\nsecondary_player_category: 8\r\ndateofbirth: 12/2/2001 12:00:00 AM\r\nphoto:  \r\nisactive: 1\r\ncreatedate: 8/7/2018 2:24:08 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(81, 'Info', '2018-08-07 16:59:47', 'Add Player', '24: 24 is created.\r\nNew data are as follow:\r\nplayerid: 24\r\nenroll_number: 57689\r\nHPDTid: HPDT01\r\nplayer_name: Thet Thet\r\ngender: 0\r\naddress: Yangon\r\nnrc: 188432\r\npassport: 0987553\r\nafcid: 0034\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 9\r\nsecondary_player_category: 10\r\ndateofbirth: 4/11/2000 12:00:00 AM\r\nphoto:  \r\nisactive: 1\r\ncreatedate: 8/7/2018 4:59:44 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(82, 'Info', '2018-08-07 17:01:50', 'Update Player', '24: Thet Thet is updated.\r\nOld data are as follow:\r\nplayerid: 24\r\nenroll_number: 57689\r\nHPDTid: HPDT01\r\nplayer_name: Thet Thet\r\ngender: 0\r\naddress: Yangon\r\nnrc: 188432\r\npassport: 0987553\r\nafcid: 0034\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 9\r\nsecondary_player_category: 10\r\ndateofbirth: 4/11/2000 12:00:00 AM\r\nphoto: 24.jpg\r\nisactive: 1\r\ncreatedate: 8/7/2018 4:59:44 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(83, 'Info', '2018-08-08 09:32:18', 'Add Admin', '3: pont is created.\r\nNew data are as follow:\r\nAdminID: 3\r\nAdminLevelID: 1\r\nAdminName: pont\r\nLoginName: pont\r\nPassword: cJqB5V59MkiWDWz2eAaSNXLucbXlqjkW\r\nsalt: buFS/sF8RnTGwvu2lP/EQgAw2nuciX1q\r\nImagePath: \r\nlogin_fail_count: 0\r\naccess_status: 0\r\nEmail: naziqueen592@gmail.com\r\ncreated_date: 8/8/2018 9:32:15 AM\r\nmodified_date: 8/8/2018 9:32:15 AM', 1, 'admin', '127.0.0.1'),
(84, 'Info', '2018-08-08 09:33:07', 'Admin Reset Password', 'Reset Password\r\nGiven data are as follow:\r\nAdminID = \'3\'', 1, 'admin', '127.0.0.1'),
(85, 'Info', '2018-08-08 13:44:40', 'Add Player', '25: 25 is created.\r\nNew data are as follow:\r\nplayerid: 25\r\nenroll_number: 40089\r\nHPDTid: HPDT5678\r\nplayer_name: Kg Sat\r\ngender: 1\r\naddress: Mon\r\nnrc: 4/938439\r\npassport: 1298773\r\nafcid: 099877\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 7\r\nsecondary_player_category: 8\r\ndateofbirth: 3/11/1997 12:00:00 AM\r\nphoto:  \r\nisactive: 1\r\ncreatedate: 8/8/2018 1:44:37 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(86, 'Info', '2018-08-09 13:43:51', 'Update Player', '3: 3 is created.\r\nNew data are as follow:\r\nplayer_clubid: 3\r\nplayerid: 25\r\nsub_clubid: 1\r\nclubid: 2\r\njoin_date: 1/1/2018 12:00:00 AM\r\nend_date: 1/1/2020 12:00:00 AM\r\ncreatedate: 8/9/2018 1:43:48 PM\r\ncreateuser: 1\r\nisactive: 1', 1, 'admin', '127.0.0.1'),
(87, 'Info', '2018-08-09 13:48:57', 'Update Player', '3: 3 is created.\r\nNew data are as follow:\r\nplayer_clubid: 3\r\nplayerid: 25\r\nsub_clubid: 1\r\nclubid: 2\r\njoin_date: 1/1/2018 12:00:00 AM\r\nend_date: 1/1/2021 12:00:00 AM\r\ncreatedate: 8/9/2018 1:48:54 PM\r\ncreateuser: 1\r\nisactive: 1', 1, 'admin', '127.0.0.1'),
(88, 'Info', '2018-08-09 14:00:34', 'Add Admin', '4: Ag Ag is created.\r\nNew data are as follow:\r\nAdminID: 4\r\nAdminLevelID: 1\r\nAdminName: Ag Ag\r\nLoginName: agag\r\nPassword: SzKrYj+KLRcD/h5xjUtWqTY6z8DsQgik\r\nsalt: MVKLALehouKM6sB0+iJT7gIHKX6F7PiO\r\nImagePath: \r\nlogin_fail_count: 0\r\naccess_status: 0\r\nEmail: agag@gmail.com\r\ncreated_date: 8/9/2018 2:00:31 PM\r\nmodified_date: 8/9/2018 2:00:31 PM', 1, 'admin', '127.0.0.1'),
(89, 'Info', '2018-08-09 14:05:57', 'Update Admin', '4: aa is updated.\r\nOld data are as follow:\r\nAdminID: 4\r\nAdminLevelID: 1\r\nAdminName: Ag Ag\r\nLoginName: agag\r\nPassword: SzKrYj+KLRcD/h5xjUtWqTY6z8DsQgik\r\nsalt: MVKLALehouKM6sB0+iJT7gIHKX6F7PiO\r\nImagePath: 4.jpg\r\nlogin_fail_count: 0\r\naccess_status: 0\r\nEmail: agag@gmail.com\r\ncreated_date: 8/9/2018 2:00:31 PM\r\nmodified_date: 8/9/2018 2:00:31 PM', 1, 'admin', '127.0.0.1'),
(90, 'Info', '2018-08-09 14:11:32', 'Update Player', '24: Thet Thet is updated.\r\nOld data are as follow:\r\nplayerid: 24\r\nenroll_number: 57689\r\nHPDTid: HPDT01\r\nplayer_name: Thet Thet\r\ngender: 0\r\naddress: Mandalay\r\nnrc: 188432\r\npassport: 0987553\r\nafcid: 0034\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 7\r\nsecondary_player_category: 10\r\ndateofbirth: 4/11/2000 12:00:00 AM\r\nphoto: 24.jpg\r\nisactive: 1\r\ncreatedate: 8/7/2018 5:01:49 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(91, 'Info', '2018-08-09 14:14:49', 'Add Player', '26: 26 is created.\r\nNew data are as follow:\r\nplayerid: 26\r\nenroll_number: 093747\r\nHPDTid: HPDT44\r\nplayer_name: Htet\r\ngender: 1\r\naddress: yangon\r\nnrc: 188000\r\npassport: qwqw\r\nafcid: 455\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 10\r\nsecondary_player_category: 7\r\ndateofbirth: 2/13/2008 12:00:00 AM\r\nphoto:  \r\nisactive: 1\r\ncreatedate: 8/9/2018 2:14:47 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(92, 'Info', '2018-08-09 14:18:54', 'Update Player', '26: Htet is updated.\r\nOld data are as follow:\r\nplayerid: 26\r\nenroll_number: 093747\r\nHPDTid: HPDT44\r\nplayer_name: Htet\r\ngender: 1\r\naddress: yangon\r\nnrc: 188000\r\npassport: qwqw\r\nafcid: 455\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 10\r\nsecondary_player_category: 7\r\ndateofbirth: 2/13/2008 12:00:00 AM\r\nphoto: 26.jpg\r\nisactive: 1\r\ncreatedate: 8/9/2018 2:14:47 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(93, 'Info', '2018-08-09 14:20:57', 'Update Player', '3: 3 is created.\r\nNew data are as follow:\r\nplayer_clubid: 3\r\nplayerid: 25\r\nsub_clubid: 1\r\nclubid: 2\r\njoin_date: 1/1/2018 12:00:00 AM\r\nend_date: 2/1/2022 12:00:00 AM\r\ncreatedate: 8/9/2018 2:20:54 PM\r\ncreateuser: 1\r\nisactive: 1', 1, 'admin', '127.0.0.1'),
(94, 'Info', '2018-08-09 14:23:04', 'Update Player', '3: 3 is created.\r\nNew data are as follow:\r\nplayer_clubid: 3\r\nplayerid: 25\r\nsub_clubid: 1\r\nclubid: 2\r\njoin_date: 5/1/2019 12:00:00 AM\r\nend_date: 2/1/2022 12:00:00 AM\r\ncreatedate: 8/9/2018 2:23:01 PM\r\ncreateuser: 1\r\nisactive: 1', 1, 'admin', '127.0.0.1'),
(95, 'Info', '2018-08-09 14:24:55', 'Update Player', '3: 3 is created.\r\nNew data are as follow:\r\nplayer_clubid: 3\r\nplayerid: 25\r\nsub_clubid: 1\r\nclubid: 2\r\njoin_date: 7/1/2019 12:00:00 AM\r\nend_date: 2/1/2022 12:00:00 AM\r\ncreatedate: 8/9/2018 2:24:53 PM\r\ncreateuser: 1\r\nisactive: 1', 1, 'admin', '127.0.0.1'),
(96, 'Info', '2018-08-09 14:28:13', 'Update Player', '3: 3 is created.\r\nNew data are as follow:\r\nplayer_clubid: 3\r\nplayerid: 25\r\nsub_clubid: 1\r\nclubid: 2\r\njoin_date: 7/1/2019 12:00:00 AM\r\nend_date: 2/3/2022 12:00:00 AM\r\ncreatedate: 8/9/2018 2:28:10 PM\r\ncreateuser: 1\r\nisactive: 1', 1, 'admin', '127.0.0.1'),
(97, 'Info', '2018-08-09 14:31:07', 'Update Player', '3: 3 is created.\r\nNew data are as follow:\r\nplayer_clubid: 3\r\nplayerid: 25\r\nsub_clubid: 1\r\nclubid: 2\r\njoin_date: 7/31/2019 12:00:00 AM\r\nend_date: 2/3/2022 12:00:00 AM\r\ncreatedate: 8/9/2018 2:31:04 PM\r\ncreateuser: 1\r\nisactive: 1', 1, 'admin', '127.0.0.1'),
(98, 'Info', '2018-08-09 14:39:29', 'Update Player', '26: Htet is updated.\r\nOld data are as follow:\r\nplayerid: 26\r\nenroll_number: 093747\r\nHPDTid: HPDT44\r\nplayer_name: Htet\r\ngender: 1\r\naddress: yangon\r\nnrc: 188000\r\npassport: qwqw\r\nafcid: 455\r\nposition: 3\r\nnationality: 12\r\nprimary_player_category: 7\r\nsecondary_player_category: 10\r\ndateofbirth: 2/13/2008 12:00:00 AM\r\nphoto: 26.jpg\r\nisactive: 1\r\ncreatedate: 8/9/2018 2:18:53 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(99, 'Info', '2018-08-09 14:40:43', 'Update Player', '26: Htetaa is updated.\r\nOld data are as follow:\r\nplayerid: 26\r\nenroll_number: 093747\r\nHPDTid: HPDT44\r\nplayer_name: Htetaa\r\ngender: 1\r\naddress: yangon\r\nnrc: 188000\r\npassport: qwqw\r\nafcid: 455\r\nposition: 3\r\nnationality: 12\r\nprimary_player_category: 7\r\nsecondary_player_category: 10\r\ndateofbirth: 2/13/2008 12:00:00 AM\r\nphoto: 26.jpg\r\nisactive: 1\r\ncreatedate: 8/9/2018 2:39:28 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(100, 'Info', '2018-08-09 14:45:07', 'Update Player', '26: Htetbb is updated.\r\nOld data are as follow:\r\nplayerid: 26\r\nenroll_number: 093747\r\nHPDTid: HPDT44\r\nplayer_name: Htetbb\r\ngender: 1\r\naddress: yangon\r\nnrc: 188000\r\npassport: qwqw\r\nafcid: 455\r\nposition: 3\r\nnationality: 12\r\nprimary_player_category: 7\r\nsecondary_player_category: 10\r\ndateofbirth: 2/13/2008 12:00:00 AM\r\nphoto: 26.jpg\r\nisactive: 1\r\ncreatedate: 8/9/2018 2:40:42 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(101, 'Info', '2018-08-09 14:56:03', 'Update Player', '26: Htetbbmmmm is updated.\r\nOld data are as follow:\r\nplayerid: 26\r\nenroll_number: 093747\r\nHPDTid: HPDT44\r\nplayer_name: Htetbbmmmm\r\ngender: 1\r\naddress: yangon\r\nnrc: 188000\r\npassport: qwqw\r\nafcid: 455\r\nposition: 3\r\nnationality: 12\r\nprimary_player_category: 7\r\nsecondary_player_category: 10\r\ndateofbirth: 2/13/2008 12:00:00 AM\r\nphoto: 26.jpg\r\nisactive: 1\r\ncreatedate: 8/9/2018 2:45:06 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(102, 'Info', '2018-08-09 14:58:56', 'Update Player', '25: Kg Sat is updated.\r\nOld data are as follow:\r\nplayerid: 25\r\nenroll_number: 40089\r\nHPDTid: HPDT5678\r\nplayer_name: Kg Sat\r\ngender: 1\r\naddress: Mon\r\nnrc: 4/938439\r\npassport: 1298773\r\nafcid: 099877\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 7\r\nsecondary_player_category: 8\r\ndateofbirth: 3/11/1997 12:00:00 AM\r\nphoto: 25.jpg\r\nisactive: 1\r\ncreatedate: 8/8/2018 1:44:37 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(103, 'Info', '2018-08-09 14:59:58', 'Update Player', '25: Kg Sattttt is updated.\r\nOld data are as follow:\r\nplayerid: 25\r\nenroll_number: 40089\r\nHPDTid: HPDT5678\r\nplayer_name: Kg Sattttt\r\ngender: 1\r\naddress: Mon\r\nnrc: 4/938439\r\npassport: 1298773\r\nafcid: 099877\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 7\r\nsecondary_player_category: 8\r\ndateofbirth: 3/11/1997 12:00:00 AM\r\nphoto: 25.jpg\r\nisactive: 1\r\ncreatedate: 8/9/2018 2:58:55 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(104, 'Info', '2018-08-09 15:01:50', 'Update Player', '3: 3 is created.\r\nNew data are as follow:\r\nplayer_clubid: 3\r\nplayerid: 25\r\nsub_clubid: 1\r\nclubid: 2\r\njoin_date: 7/31/2019 12:00:00 AM\r\nend_date: 11/2/2026 12:00:00 AM\r\ncreatedate: 8/9/2018 3:01:48 PM\r\ncreateuser: 1\r\nisactive: 1', 1, 'admin', '127.0.0.1'),
(105, 'Info', '2018-08-09 15:07:35', 'Update Player', '3: 3 is created.\r\nNew data are as follow:\r\nplayer_clubid: 3\r\nplayerid: 25\r\nsub_clubid: 1\r\nclubid: 2\r\njoin_date: 1/28/2020 12:00:00 AM\r\nend_date: 11/2/2026 12:00:00 AM\r\ncreatedate: 8/9/2018 3:07:32 PM\r\ncreateuser: 1\r\nisactive: 1', 1, 'admin', '127.0.0.1'),
(106, 'Info', '2018-08-10 11:24:12', 'Delete player', '26 is deleted.\r\nOld data are as follow:\r\nplayerid: 26\r\nenroll_number: 093747\r\nHPDTid: HPDT44\r\nplayer_name: Htetbll\r\ngender: 1\r\naddress: yangon\r\nnrc: 188000\r\npassport: qwqw\r\nafcid: 455\r\nposition: 3\r\nnationality: 12\r\nprimary_player_category: 7\r\nsecondary_player_category: 10\r\ndateofbirth: 2/13/2008 12:00:00 AM\r\nphoto: 26.jpg\r\nisactive: 1\r\ncreatedate: 8/9/2018 2:56:02 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(107, 'Info', '2018-08-10 14:37:38', 'Delete player attachment', '15 is deleted.\r\nOld data are as follow:\r\nattachid: 15\r\nplayerid: 25\r\nattachfilename: 25.pdf', 1, 'admin', '127.0.0.1'),
(108, 'Info', '2018-08-10 14:41:05', 'Delete player attachment', '11 is deleted.\r\nOld data are as follow:\r\nattachid: 11\r\nplayerid: 23\r\nattachfilename: 23.pptx', 1, 'admin', '127.0.0.1'),
(109, 'Info', '2018-08-10 14:43:47', 'Delete player attachment', '12 is deleted.\r\nOld data are as follow:\r\nattachid: 12\r\nplayerid: 23\r\nattachfilename: 23.pptx', 1, 'admin', '127.0.0.1'),
(110, 'Info', '2018-08-10 14:44:45', 'Delete player attachment', '14 is deleted.\r\nOld data are as follow:\r\nattachid: 14\r\nplayerid: 25\r\nattachfilename: 25.pptx', 1, 'admin', '127.0.0.1'),
(111, 'Info', '2018-08-10 14:48:45', 'Add Player', '27: 27 is created.\r\nNew data are as follow:\r\nplayerid: 27\r\nenroll_number: 30002\r\nHPDTid: HPDT456\r\nplayer_name: Mg Mg\r\ngender: 1\r\naddress: Yangon\r\nnrc: 2/37483\r\npassport: 1.MMjwiei\r\nafcid: 0982\r\nposition: 5\r\nnationality: 4\r\nprimary_player_category: 10\r\nsecondary_player_category: 7\r\ndateofbirth: 12/4/2001 12:00:00 AM\r\nphoto:  \r\nisactive: 1\r\ncreatedate: 8/10/2018 2:48:42 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(112, 'Info', '2018-08-10 14:51:52', 'Delete player attachment', '18 is deleted.\r\nOld data are as follow:\r\nattachid: 18\r\nplayerid: 27\r\nattachfilename: 27.jpg', 1, 'admin', '127.0.0.1'),
(113, 'Info', '2018-08-10 14:55:17', 'Delete player attachment', '19 is deleted.\r\nOld data are as follow:\r\nattachid: 19\r\nplayerid: 27\r\nattachfilename: 27.pptx', 1, 'admin', '127.0.0.1'),
(114, 'Info', '2018-08-10 14:56:52', 'Add Player', '27: 27 is created.\r\nNew data are as follow:\r\nplayerid: 27\r\nenroll_number: 30002\r\nHPDTid: HPDT456\r\nplayer_name: Mg Mg\r\ngender: 1\r\naddress: Yangon\r\nnrc: 2/37483\r\npassport: 1.MMjwiei\r\nafcid: 0982\r\nposition: 5\r\nnationality: 4\r\nprimary_player_category: 10\r\nsecondary_player_category: 7\r\ndateofbirth: 12/4/2001 12:00:00 AM\r\nphoto: 27.jpg\r\nisactive: 1\r\ncreatedate: 8/10/2018 2:48:42 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(115, 'Info', '2018-08-10 15:02:08', 'Delete player attachment', '20 is deleted.\r\nOld data are as follow:\r\nattachid: 20\r\nplayerid: 27\r\nattachfilename: 27.docx', 1, 'admin', '127.0.0.1'),
(116, 'Info', '2018-08-10 15:54:53', 'Add Player', '27: 27 is created.\r\nNew data are as follow:\r\nplayerid: 27\r\nenroll_number: 30002\r\nHPDTid: HPDT456\r\nplayer_name: Mg Mg\r\ngender: 1\r\naddress: Yangon\r\nnrc: 2/37483\r\npassport: 1.MMjwiei\r\nafcid: 0982\r\nposition: 5\r\nnationality: 4\r\nprimary_player_category: 10\r\nsecondary_player_category: 7\r\ndateofbirth: 12/4/2001 12:00:00 AM\r\nphoto: 27.jpg\r\nisactive: 1\r\ncreatedate: 8/10/2018 2:48:42 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(117, 'Info', '2018-08-10 16:05:27', 'Add Player', '25: 25 is created.\r\nNew data are as follow:\r\nplayerid: 25\r\nenroll_number: 40089\r\nHPDTid: HPDT5678\r\nplayer_name: Kg Sat\r\ngender: 1\r\naddress: Mon\r\nnrc: 4/938439\r\npassport: 1298773\r\nafcid: 099877\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 7\r\nsecondary_player_category: 8\r\ndateofbirth: 3/11/1997 12:00:00 AM\r\nphoto: 25.jpg\r\nisactive: 1\r\ncreatedate: 8/9/2018 2:59:58 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(118, 'Info', '2018-08-10 17:28:52', 'Add Player', '28: 28 is created.\r\nNew data are as follow:\r\nplayerid: 28\r\nenroll_number: 55000\r\nHPDTid: HPDT654\r\nplayer_name: Aung Kyaw\r\ngender: 1\r\naddress: Bago\r\nnrc: 2/823983\r\npassport: 128h8883\r\nafcid: 8976\r\nposition: 3\r\nnationality: 12\r\nprimary_player_category: 7\r\nsecondary_player_category: 10\r\ndateofbirth: 1/28/2001 12:00:00 AM\r\nphoto:  \r\nisactive: 1\r\ncreatedate: 8/10/2018 5:28:49 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(119, 'Info', '2018-08-10 17:32:42', 'Delete player', '28 is deleted.\r\nOld data are as follow:\r\nplayerid: 28\r\nenroll_number: 55000\r\nHPDTid: HPDT654\r\nplayer_name: Aung Kyaw\r\ngender: 1\r\naddress: Bago\r\nnrc: 2/823983\r\npassport: 128h8883\r\nafcid: 8976\r\nposition: 3\r\nnationality: 12\r\nprimary_player_category: 7\r\nsecondary_player_category: 10\r\ndateofbirth: 1/28/2001 12:00:00 AM\r\nphoto: 28.jpg\r\nisactive: 1\r\ncreatedate: 8/10/2018 5:28:49 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(120, 'Info', '2018-08-10 17:35:45', 'Add Player', '29: 29 is created.\r\nNew data are as follow:\r\nplayerid: 29\r\nenroll_number: 40099\r\nHPDTid: sfffg\r\nplayer_name: Aung Aung\r\ngender: 1\r\naddress: ygn\r\nnrc: 34545\r\npassport: 23234\r\nafcid: 434\r\nposition: 3\r\nnationality: 12\r\nprimary_player_category: 10\r\nsecondary_player_category: 7\r\ndateofbirth: 6/25/2000 12:00:00 AM\r\nphoto:  \r\nisactive: 1\r\ncreatedate: 8/10/2018 5:35:42 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(121, 'Info', '2018-08-10 17:43:17', 'Add Player', '30: 30 is created.\r\nNew data are as follow:\r\nplayerid: 30\r\nenroll_number: 55555\r\nHPDTid: 5trfg\r\nplayer_name: gr\r\ngender: 0\r\naddress: 4gg\r\nnrc: 455\r\npassport: 3434565\r\nafcid: wew\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 7\r\nsecondary_player_category: 7\r\ndateofbirth: 4/2/2002 12:00:00 AM\r\nphoto:  \r\nisactive: 1\r\ncreatedate: 8/10/2018 5:43:14 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(122, 'Info', '2018-08-11 09:08:22', 'Add Player', '25: 25 is created.\r\nNew data are as follow:\r\nplayerid: 25\r\nenroll_number: 40089\r\nHPDTid: HPDT5678\r\nplayer_name: Kg Sat\r\ngender: 1\r\naddress: Mon\r\nnrc: 4/938439\r\npassport: 1298773\r\nafcid: 099877\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 7\r\nsecondary_player_category: 8\r\ndateofbirth: 3/11/1997 12:00:00 AM\r\nphoto: 25.jpg\r\nisactive: 1\r\ncreatedate: 8/9/2018 2:59:58 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(123, 'Info', '2018-08-11 09:24:26', 'Add Player', '24: 24 is created.\r\nNew data are as follow:\r\nplayerid: 24\r\nenroll_number: 57689\r\nHPDTid: HPDT01\r\nplayer_name: Thet Aung\r\ngender: 0\r\naddress: Mandalay\r\nnrc: 188432\r\npassport: 0987553\r\nafcid: 0034\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 7\r\nsecondary_player_category: 10\r\ndateofbirth: 4/11/2000 12:00:00 AM\r\nphoto: 24.jpg\r\nisactive: 1\r\ncreatedate: 8/9/2018 2:11:31 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(124, 'Info', '2018-08-11 09:27:39', 'Add Player', '6: 6 is created.\r\nNew data are as follow:\r\nplayerid: 6\r\nenroll_number: 00055\r\nHPDTid: 2222\r\nplayer_name: Aye Aye\r\ngender: 0\r\naddress: Yangon\r\nnrc: 454545\r\npassport: 34343\r\nafcid: 3330\r\nposition: 3\r\nnationality: 12\r\nprimary_player_category: 9\r\nsecondary_player_category: 9\r\ndateofbirth: 9/8/1998 12:00:00 AM\r\nphoto:  \r\nisactive: 1\r\ncreatedate: 8/3/2018 12:00:11 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(125, 'Info', '2018-08-11 09:37:22', 'Add Player', '31: 31 is created.\r\nNew data are as follow:\r\nplayerid: 31\r\nenroll_number: 80010\r\nHPDTid: HPDT0002\r\nplayer_name: Kyaw Thura\r\ngender: 1\r\naddress: Taung Gyi\r\nnrc: 12/TT6374\r\npassport: 103844\r\nafcid: 8756\r\nposition: 3\r\nnationality: 12\r\nprimary_player_category: 10\r\nsecondary_player_category: 7\r\ndateofbirth: 3/1/2000 12:00:00 AM\r\nphoto:  \r\nisactive: 1\r\ncreatedate: 8/11/2018 9:37:19 AM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(126, 'Info', '2018-08-11 09:42:27', 'Add Player', '31: 31 is created.\r\nNew data are as follow:\r\nplayerid: 31\r\nenroll_number: 80010\r\nHPDTid: HPDT0002\r\nplayer_name: Kyaw Thura\r\ngender: 1\r\naddress: Taung Gyi\r\nnrc: 12/TT6374\r\npassport: 103844\r\nafcid: 8756\r\nposition: 3\r\nnationality: 12\r\nprimary_player_category: 10\r\nsecondary_player_category: 7\r\ndateofbirth: 3/1/2000 12:00:00 AM\r\nphoto: 31.jpg\r\nisactive: 1\r\ncreatedate: 8/11/2018 9:37:19 AM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(127, 'Info', '2018-08-11 10:02:43', 'Delete player attachment', '32 is deleted.\r\nOld data are as follow:\r\nattachid: 32\r\nplayerid: 31\r\nattachfilename: 31.pdf', 1, 'admin', '127.0.0.1'),
(128, 'Info', '2018-08-11 10:03:29', 'Add Player', '31: 31 is created.\r\nNew data are as follow:\r\nplayerid: 31\r\nenroll_number: 80010\r\nHPDTid: HPDT0002\r\nplayer_name: Kyaw Thura\r\ngender: 1\r\naddress: Taung Gyi\r\nnrc: 12/TT6374\r\npassport: 103844\r\nafcid: 8756\r\nposition: 3\r\nnationality: 12\r\nprimary_player_category: 10\r\nsecondary_player_category: 7\r\ndateofbirth: 3/1/2000 12:00:00 AM\r\nphoto: 31.jpg\r\nisactive: 1\r\ncreatedate: 8/11/2018 9:37:19 AM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(129, 'Info', '2018-08-11 10:10:35', 'Add Player', '27: 27 is created.\r\nNew data are as follow:\r\nplayerid: 27\r\nenroll_number: 30002\r\nHPDTid: HPDT456\r\nplayer_name: Mg Mg\r\ngender: 1\r\naddress: Yangon\r\nnrc: 2/37483\r\npassport: 1.MMjwiei\r\nafcid: 0982\r\nposition: 5\r\nnationality: 4\r\nprimary_player_category: 10\r\nsecondary_player_category: 7\r\ndateofbirth: 12/4/2001 12:00:00 AM\r\nphoto: 27.jpg\r\nisactive: 1\r\ncreatedate: 8/10/2018 2:48:42 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(130, 'Info', '2018-08-11 13:46:35', 'Add Player', '32: 32 is created.\r\nNew data are as follow:\r\nplayerid: 32\r\nenroll_number: 20001\r\nHPDTid: HPDT3422\r\nplayer_name: Mg Aung\r\ngender: 1\r\naddress: Shan\r\nnrc: 12/LL2839\r\npassport: 2536266\r\nafcid: 93477\r\nposition: 5\r\nnationality: 12\r\nprimary_player_category: 8\r\nsecondary_player_category: 7\r\ndateofbirth: 10/1/2001 12:00:00 AM\r\nphoto:  \r\nisactive: 1\r\ncreatedate: 8/11/2018 1:46:32 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(131, 'Info', '2018-08-11 14:03:23', 'Update Player', '4: 4 is created.\r\nNew data are as follow:\r\nplayer_clubid: 4\r\nplayerid: 32\r\nsub_clubid: 2\r\nclubid: 1\r\njoin_date: 8/11/2018 12:00:00 AM\r\nend_date: 8/31/2021 12:00:00 AM\r\ncreatedate: 8/11/2018 2:03:21 PM\r\ncreateuser: 1\r\nisactive: 1', 1, 'admin', '127.0.0.1'),
(132, 'Info', '2018-08-11 14:16:30', 'Delete player attachment', '36 is deleted.\r\nOld data are as follow:\r\nattachid: 36\r\nplayerid: 32\r\nattachfilename: 32.jpg', 1, 'admin', '127.0.0.1');
INSERT INTO `tbl_eventlog` (`ID`, `LogType`, `LogDateTime`, `Source`, `LogMessage`, `UserID`, `UserType`, `ipAddress`) VALUES
(133, 'Info', '2018-08-11 14:19:51', 'Delete player attachment', '31 is deleted.\r\nOld data are as follow:\r\nattachid: 31\r\nplayerid: 31\r\nattachfilename: 31.xls', 1, 'admin', '127.0.0.1'),
(134, 'Info', '2018-08-11 14:26:55', 'Delete player', '30 is deleted.\r\nOld data are as follow:\r\nplayerid: 30\r\nenroll_number: 55555\r\nHPDTid: 5trfg\r\nplayer_name: gr\r\ngender: 0\r\naddress: 4gg\r\nnrc: 455\r\npassport: 3434565\r\nafcid: wew\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 7\r\nsecondary_player_category: 7\r\ndateofbirth: 4/2/2002 12:00:00 AM\r\nphoto:  \r\nisactive: 1\r\ncreatedate: 8/10/2018 5:43:14 PM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(135, 'Info', '2018-08-13 09:44:12', 'Delete player attachment', '35 is deleted.\r\nOld data are as follow:\r\nattachid: 35\r\nplayerid: 32\r\nattachfilename: 32.xls', 1, 'admin', '127.0.0.1'),
(136, 'Info', '2018-08-14 10:07:39', 'Add Club', '8: 8 is created.\r\nNew data are as follow:\r\nclubid: 8\r\nclubname: Yadana Pone\r\nteam_manager: U San Thu\r\nphone: 093474834\r\nemail: santhu@gmail.com\r\naddress: Mandalay\r\nlogo: \r\ncreatedate: 8/14/2018 10:07:34 AM\r\ncreateuser: 1\r\nisactive: 1', 1, 'admin', '127.0.0.1'),
(137, 'Info', '2018-08-14 10:12:31', 'Add Club', '9: 9 is created.\r\nNew data are as follow:\r\nclubid: 9\r\nclubname: Yadanrpone\r\nteam_manager: U Chit\r\nphone: 09348374\r\nemail: cc@gmail.com\r\naddress: Mandalay\r\nlogo: \r\ncreatedate: 8/14/2018 10:12:27 AM\r\ncreateuser: 1\r\nisactive: 1', 1, 'admin', '127.0.0.1'),
(138, 'Info', '2018-08-14 10:21:47', 'Add Club', '10: 10 is created.\r\nNew data are as follow:\r\nclubid: 10\r\nclubname: Sagaing FC\r\nteam_manager: U Mg Mg\r\nphone: 096364445\r\nemail: mm@gmail.com\r\naddress: Sagaing\r\nlogo: \r\ncreatedate: 8/14/2018 10:21:43 AM\r\ncreateuser: 1\r\nisactive: 1', 1, 'admin', '127.0.0.1'),
(139, 'Info', '2018-08-14 15:07:03', 'Add Club', '11: 11 is created.\r\nNew data are as follow:\r\nclubid: 11\r\nclubname: UMM\r\nteam_manager: mgmg\r\nphone: 0937473434\r\nemail: mmm@gmail.com\r\naddress: yangon\r\nlogo: \r\ncreatedate: 8/14/2018 3:06:49 PM\r\ncreateuser: 1\r\nisactive: 1', 1, 'admin', '127.0.0.1'),
(140, 'Info', '2018-08-14 15:43:39', 'Add Club', '11: 11 is created.\r\nNew data are as follow:\r\nclubid: 11\r\nclubname: UMM\r\nteam_manager: kyawaung\r\nphone: 0937473434\r\nemail: mmm@gmail.com\r\naddress: yangon\r\nlogo: 11.png\r\ncreatedate: 8/14/2018 3:06:49 PM\r\ncreateuser: 1\r\nisactive: 1', 1, 'admin', '127.0.0.1'),
(141, 'Info', '2018-08-14 15:59:16', 'Delete Club', '6 is deleted.\r\nOld data are as follow:\r\nclubid: 6\r\nclubname: Bago United\r\nteam_manager: Thura\r\nphone: 0934832932\r\nemail: thura@gmail.com\r\naddress: Bago\r\nlogo: \r\ncreatedate: 8/13/2018 5:15:28 PM\r\ncreateuser: 1\r\nisactive: 1', 1, 'admin', '127.0.0.1'),
(142, 'Info', '2018-08-14 16:03:44', 'Delete Club', '10 is deleted.\r\nOld data are as follow:\r\nclubid: 10\r\nclubname: Sagaing FC\r\nteam_manager: U Mg Mg\r\nphone: 096364445\r\nemail: mm@gmail.com\r\naddress: Sagaing\r\nlogo: 10.png\r\ncreatedate: 8/14/2018 10:21:43 AM\r\ncreateuser: 1\r\nisactive: 1', 1, 'admin', '127.0.0.1'),
(143, 'Info', '2018-08-14 16:33:22', 'Delete player attachment', '28 is deleted.\r\nOld data are as follow:\r\nattachid: 28\r\nplayerid: 25\r\nattachfilename: 25.jpg', 1, 'admin', '127.0.0.1'),
(144, 'Info', '2018-08-15 10:43:02', 'Add Player', '33: 33 is created.\r\nNew data are as follow:\r\nplayerid: 33\r\nenroll_number: 20000\r\nHPDTid: 123456\r\nplayer_name: AA\r\ngender: 1\r\naddress: AAA\r\nnrc: 12\r\npassport: 12\r\nafcid: AA\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 7\r\nsecondary_player_category: 8\r\ndateofbirth: 8/1/2018 12:00:00 AM\r\nphoto:  \r\nisactive: 1\r\ncreatedate: 8/15/2018 10:42:59 AM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(145, 'Info', '2018-08-15 10:43:43', 'Add Player', '33: 33 is created.\r\nNew data are as follow:\r\nplayerid: 33\r\nenroll_number: 20000\r\nHPDTid: 123456\r\nplayer_name: AA\r\ngender: 1\r\naddress: AAA\r\nnrc: 12\r\npassport: 12\r\nafcid: AA\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 7\r\nsecondary_player_category: 8\r\ndateofbirth: 8/1/2018 12:00:00 AM\r\nphoto: 33.jpg\r\nisactive: 1\r\ncreatedate: 8/15/2018 10:42:59 AM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(146, 'Info', '2018-08-15 10:44:54', 'Add Player', '33: 33 is created.\r\nNew data are as follow:\r\nplayerid: 33\r\nenroll_number: 20000\r\nHPDTid: 123456\r\nplayer_name: AA\r\ngender: 1\r\naddress: AAA\r\nnrc: 12\r\npassport: 12\r\nafcid: AA\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 7\r\nsecondary_player_category: 8\r\ndateofbirth: 8/1/2018 12:00:00 AM\r\nphoto: 33.jpg\r\nisactive: 1\r\ncreatedate: 8/15/2018 10:42:59 AM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(147, 'Info', '2018-08-15 10:45:20', 'Delete player attachment', '35 is deleted.\r\nOld data are as follow:\r\nattachid: 35\r\nplayerid: 33\r\nattachfilename: 33.jpg', 1, 'admin', '127.0.0.1'),
(148, 'Info', '2018-08-15 10:45:30', 'Delete player attachment', '39 is deleted.\r\nOld data are as follow:\r\nattachid: 39\r\nplayerid: 33\r\nattachfilename: 33.jpeg', 1, 'admin', '127.0.0.1'),
(149, 'Info', '2018-08-15 10:46:12', 'Add Player', '33: 33 is created.\r\nNew data are as follow:\r\nplayerid: 33\r\nenroll_number: 20000\r\nHPDTid: 123456\r\nplayer_name: AA\r\ngender: 1\r\naddress: AAA\r\nnrc: 12\r\npassport: 12\r\nafcid: AA\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 7\r\nsecondary_player_category: 8\r\ndateofbirth: 8/1/2018 12:00:00 AM\r\nphoto: 33.jpg\r\nisactive: 1\r\ncreatedate: 8/15/2018 10:42:59 AM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(150, 'Info', '2018-08-15 10:48:19', 'Add Player', '33: 33 is created.\r\nNew data are as follow:\r\nplayerid: 33\r\nenroll_number: 20000\r\nHPDTid: 123456\r\nplayer_name: AA\r\ngender: 1\r\naddress: AAA\r\nnrc: 12\r\npassport: 12\r\nafcid: AA\r\nposition: 3\r\nnationality: 4\r\nprimary_player_category: 7\r\nsecondary_player_category: 8\r\ndateofbirth: 8/1/2018 12:00:00 AM\r\nphoto: 33.jpg\r\nisactive: 1\r\ncreatedate: 8/15/2018 10:42:59 AM\r\ncreateuser: 1', 1, 'admin', '127.0.0.1'),
(151, 'Info', '2018-08-15 10:58:21', 'Delete player attachment', '43 is deleted.\r\nOld data are as follow:\r\nattachid: 43\r\nplayerid: 33\r\nattachfilename: 33.jpeg', 1, 'admin', '127.0.0.1'),
(152, 'Info', '2018-08-15 10:58:55', 'Delete player attachment', '44 is deleted.\r\nOld data are as follow:\r\nattachid: 44\r\nplayerid: 33\r\nattachfilename: 33.jpg', 1, 'admin', '127.0.0.1'),
(153, 'Info', '2018-08-15 13:45:37', 'Add Admin', 'AdminID : 5\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Aung Aung\r\ncreated_date : 8/15/2018 1:45:35 PM\r\nEmail : aung@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : aung\r\nmodified_date : 8/15/2018 1:45:35 PM\r\nPassword : Tt6liIYI3NS9sZd9sx7ei0jWNXoP5iWr\r\nSalt : 7rFynOyZJJ6xM5FXiIVe0w/mbILayCHG\r\n', 1, 'admin', '127.0.0.1'),
(154, 'Info', '2018-08-15 15:41:51', 'Add General', 'id : 21\r\nname : Kayar\r\ntype : State\r\nisactive : True\r\n', 1, 'admin', '127.0.0.1'),
(155, 'Info', '2018-08-15 15:44:11', 'Add General', 'id : 22\r\nname : MaGwe\r\ntype : State\r\nisactive : True\r\n', 1, 'admin', '127.0.0.1'),
(156, 'Info', '2018-08-15 15:46:04', 'Update General', 'id : 21\r\nname : Kayar\r\ntype : State\r\nisactive : True\r\n', 1, 'admin', '127.0.0.1'),
(157, 'Info', '2018-08-15 15:48:16', 'Update General', 'id : 21\r\nname : KaChin\r\ntype : State\r\nisactive : True\r\n', 1, 'admin', '127.0.0.1'),
(158, 'Insert', '2018-08-17 13:23:13', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(159, 'Update', '2018-08-17 13:26:08', 'Update Admin', 'Updated data are as follow:\r\nAdminName : Aung Ko >>> Aung Aung\r\n', 0, 'admin', '::1'),
(160, 'Update', '2018-08-20 09:53:49', 'Update Club', 'Updated data are as follow:\r\nteam_manager : kyawaung >>> kyaw\r\n', 0, 'admin', '::1'),
(161, 'Insert', '2018-08-20 09:53:51', 'Add Sub Club', 'Created new data are as follow:\r\nsub_clubid : 17\r\nclubid : 11\r\nsub_clubname : U25\r\nisactive : True\r\ncreate_date : 8/20/2018 9:53:51 AM\r\ncreate_admin : 1\r\n', 0, 'admin', '::1'),
(162, 'Update', '2018-08-20 09:55:12', 'Update Club', 'Updated data are as follow:\r\n', 0, 'admin', '::1'),
(163, 'Insert', '2018-08-20 09:55:13', 'Add Club', 'Created new data are as follow:\r\nclubid : 12\r\nclubname : Bago United\r\nteam_manager : Thura\r\nphone : 0934832932\r\nemail : thura@gmail.com\r\naddress : Bago\r\nlogo : \r\nisactive : True\r\ncreatedate : 8/20/2018 9:55:13 AM\r\ncreateuser : 1\r\n', 0, 'admin', '::1'),
(164, 'Insert', '2018-08-20 10:35:44', 'Add Player', 'Created new data are as follow:\r\nplayerid : 46\r\nenroll_number : 8765\r\nHPDTid : 69\r\nplayer_name : Lucy\r\ngender : False\r\naddress : Yangon\r\nnrc : 12/e887654\r\npassport : 882\r\nafcid : 800\r\nposition : 3\r\nnationality : 12\r\nprimary_player_category : 9\r\nsecondary_player_category : 10\r\ndateofbirth : 2/2/1998 12:00:00 AM\r\nphoto :  \r\nisactive : True\r\ncreatedate : 8/20/2018 10:35:43 AM\r\ncreateuser : 1\r\n', 0, 'admin', '::1'),
(165, 'Insert', '2018-08-20 10:37:46', 'Add Player', 'Created new data are as follow:\r\nplayerid : 47\r\nenroll_number : 77\r\nHPDTid : 56\r\nplayer_name : Joone\r\ngender : True\r\naddress : hh\r\nnrc : 3/4546\r\npassport : 42222\r\nafcid : 44\r\nposition : 3\r\nnationality : 4\r\nprimary_player_category : 7\r\nsecondary_player_category : 8\r\ndateofbirth : 12/21/2010 12:00:00 AM\r\nphoto :  \r\nisactive : True\r\ncreatedate : 8/20/2018 10:37:45 AM\r\ncreateuser : 1\r\n', 0, 'admin', '::1'),
(166, 'Update', '2018-08-20 10:46:49', 'Update Club', 'Updated data are as follow:\r\n', 0, 'admin', '::1'),
(167, 'Insert', '2018-08-20 10:48:18', 'Add Sub Club', 'Created new data are as follow:\r\nsub_clubid : 19\r\nclubid : 11\r\nsub_clubname : U25\r\nisactive : True\r\ncreate_date : 8/20/2018 10:48:13 AM\r\ncreate_admin : 1\r\n', 0, 'admin', '::1'),
(168, 'Insert', '2018-08-20 10:48:29', 'Add Sub Club', 'Created new data are as follow:\r\nsub_clubid : 20\r\nclubid : 11\r\nsub_clubname : U23\r\nisactive : True\r\ncreate_date : 8/20/2018 10:48:26 AM\r\ncreate_admin : 1\r\n', 0, 'admin', '::1'),
(169, 'Insert', '2018-08-20 11:51:29', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(170, 'Update', '2018-08-20 14:39:28', 'Update Player Club', 'Updated data are as follow:\r\nend_date : 11/2/2026 12:00:00 AM >>> 1/29/2025 12:00:00 AM\r\ncreatedate : 8/9/2018 3:07:32 PM >>> 8/20/2018 2:39:26 PM\r\n', 0, 'admin', '::1'),
(171, 'Update', '2018-08-20 14:43:28', 'Update Player Club', 'Updated data are as follow:\r\njoin_date : 1/28/2020 12:00:00 AM >>> 1/31/2020 12:00:00 AM\r\ncreatedate : 8/20/2018 2:39:26 PM >>> 8/20/2018 2:43:27 PM\r\n', 0, 'admin', '::1'),
(172, 'Update', '2018-08-20 14:48:39', 'Update Player Club', 'Updated data are as follow:\r\nend_date : 4/30/2019 12:00:00 AM >>> 7/31/2019 12:00:00 AM\r\ncreatedate : 8/20/2018 12:00:00 AM >>> 8/20/2018 2:48:30 PM\r\n', 0, 'admin', '::1'),
(173, 'Update', '2018-08-20 14:53:30', 'Update Player Club', 'Updated data are as follow:\r\nend_date : 7/31/2019 12:00:00 AM >>> 1/23/2022 12:00:00 AM\r\ncreatedate : 8/20/2018 2:48:30 PM >>> 8/20/2018 2:53:29 PM\r\n', 0, 'admin', '::1'),
(174, 'Update', '2018-08-20 15:43:29', 'Update Player Club', 'Updated data are as follow:\r\nend_date : 2/20/2020 12:00:00 AM >>> 4/25/2022 12:00:00 AM\r\ncreatedate : 8/20/2018 12:00:00 AM >>> 8/20/2018 3:43:28 PM\r\n', 0, 'admin', '::1'),
(175, 'Update', '2018-08-20 16:08:43', 'Update Player Club', 'Updated data are as follow:\r\njoin_date : 1/31/2020 12:00:00 AM >>> 3/22/2020 12:00:00 AM\r\ncreatedate : 8/20/2018 2:43:27 PM >>> 8/20/2018 4:08:42 PM\r\n', 0, 'admin', '::1'),
(176, 'Insert', '2018-08-21 10:37:12', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(177, 'Update', '2018-08-21 13:16:24', 'Update Player Club', 'Updated data are as follow:\r\nend_date : 4/25/2022 12:00:00 AM >>> 5/31/2022 12:00:00 AM\r\n', 0, 'admin', '::1'),
(178, 'Update', '2018-08-21 13:24:04', 'Update Player Club', 'Updated data are as follow:\r\nend_date : 5/31/2022 12:00:00 AM >>> 6/30/2022 12:00:00 AM\r\n', 0, 'admin', '::1'),
(179, 'Insert', '2018-08-21 15:05:02', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(180, 'Delete', '2018-08-21 15:18:03', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 59\r\nplayerid : 46\r\nattachfilename : 59.xls\r\n', 0, 'admin', '::1'),
(181, 'Delete', '2018-08-21 15:18:17', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 60\r\nplayerid : 46\r\nattachfilename : 60.jpg\r\n', 0, 'admin', '::1'),
(182, 'Update', '2018-08-21 15:30:37', 'Update Player', 'Updated data are as follow:\r\nplayer_name : Kg Sat >>> oo\r\ncreatedate : 8/9/2018 2:59:58 PM >>> 8/21/2018 3:30:36 PM\r\n', 0, 'admin', '::1'),
(183, 'Delete', '2018-08-21 15:41:42', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 68\r\nplayerid : 46\r\nattachfilename : 68.png\r\n', 0, 'admin', '::1'),
(184, 'Delete', '2018-08-21 15:41:50', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 70\r\nplayerid : 46\r\nattachfilename : 70.png\r\n', 0, 'admin', '::1'),
(185, 'Delete', '2018-08-21 15:42:37', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 71\r\nplayerid : 46\r\nattachfilename : 71.png\r\n', 0, 'admin', '::1'),
(186, 'Delete', '2018-08-21 15:42:50', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 72\r\nplayerid : 46\r\nattachfilename : 72.png\r\n', 0, 'admin', '::1'),
(187, 'Delete', '2018-08-21 15:47:55', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 73\r\nplayerid : 46\r\nattachfilename : 73.jpg\r\n', 0, 'admin', '::1'),
(188, 'Insert', '2018-08-21 16:53:31', 'Add Club', 'Created new data are as follow:\r\nclubid : 12\r\nclubname : \r\nteam_manager : \r\nphone : \r\nemail : \r\naddress : \r\nlogo : \r\nisactive : True\r\ncreatedate : 8/21/2018 4:53:30 PM\r\ncreateuser : 1\r\n', 0, 'admin', '::1'),
(189, 'Insert', '2018-08-21 16:53:31', 'Add Club', 'Created new data are as follow:\r\nclubid : 14\r\nclubname : \r\nteam_manager : \r\nphone : \r\nemail : \r\naddress : \r\nlogo : \r\nisactive : True\r\ncreatedate : 8/21/2018 4:53:30 PM\r\ncreateuser : 1\r\n', 0, 'admin', '::1'),
(190, 'Insert', '2018-08-21 16:53:31', 'Add Club', 'Created new data are as follow:\r\nclubid : 13\r\nclubname : \r\nteam_manager : \r\nphone : \r\nemail : \r\naddress : \r\nlogo : \r\nisactive : True\r\ncreatedate : 8/21/2018 4:53:30 PM\r\ncreateuser : 1\r\n', 0, 'admin', '::1'),
(191, 'Insert', '2018-08-21 16:53:33', 'Add Club', 'Created new data are as follow:\r\nclubid : 15\r\nclubname : \r\nteam_manager : \r\nphone : \r\nemail : \r\naddress : \r\nlogo : \r\nisactive : True\r\ncreatedate : 8/21/2018 4:53:33 PM\r\ncreateuser : 1\r\n', 0, 'admin', '::1'),
(192, 'Insert', '2018-08-21 16:53:33', 'Add Club', 'Created new data are as follow:\r\nclubid : 16\r\nclubname : \r\nteam_manager : \r\nphone : \r\nemail : \r\naddress : \r\nlogo : \r\nisactive : True\r\ncreatedate : 8/21/2018 4:53:33 PM\r\ncreateuser : 1\r\n', 0, 'admin', '::1'),
(193, 'Insert', '2018-08-21 16:53:33', 'Add Club', 'Created new data are as follow:\r\nclubid : 17\r\nclubname : \r\nteam_manager : \r\nphone : \r\nemail : \r\naddress : \r\nlogo : \r\nisactive : True\r\ncreatedate : 8/21/2018 4:53:33 PM\r\ncreateuser : 1\r\n', 0, 'admin', '::1'),
(194, 'Insert', '2018-08-21 16:53:37', 'Add Club', 'Created new data are as follow:\r\nclubid : 20\r\nclubname : \r\nteam_manager : \r\nphone : \r\nemail : \r\naddress : \r\nlogo : \r\nisactive : True\r\ncreatedate : 8/21/2018 4:53:36 PM\r\ncreateuser : 1\r\n', 0, 'admin', '::1'),
(195, 'Insert', '2018-08-21 16:53:37', 'Add Club', 'Created new data are as follow:\r\nclubid : 19\r\nclubname : \r\nteam_manager : \r\nphone : \r\nemail : \r\naddress : \r\nlogo : \r\nisactive : True\r\ncreatedate : 8/21/2018 4:53:36 PM\r\ncreateuser : 1\r\n', 0, 'admin', '::1'),
(196, 'Insert', '2018-08-21 16:53:37', 'Add Club', 'Created new data are as follow:\r\nclubid : 18\r\nclubname : \r\nteam_manager : \r\nphone : \r\nemail : \r\naddress : \r\nlogo : \r\nisactive : True\r\ncreatedate : 8/21/2018 4:53:36 PM\r\ncreateuser : 1\r\n', 0, 'admin', '::1'),
(197, 'Insert', '2018-08-21 16:56:43', 'Add Club', 'Created new data are as follow:\r\nclubid : 21\r\nclubname : \r\nteam_manager : \r\nphone : \r\nemail : \r\naddress : \r\nlogo : \r\nisactive : True\r\ncreatedate : 8/21/2018 4:56:42 PM\r\ncreateuser : 1\r\n', 0, 'admin', '::1'),
(198, 'Update', '2018-08-21 16:57:37', 'Update Club', 'Updated data are as follow:\r\nisactive : True >>> False\r\n', 0, 'admin', '::1'),
(199, 'Delete', '2018-08-21 16:57:38', 'Delete SubClub', 'Deleted old data are as follow:\r\nsub_clubid : 30\r\nclubid : 21\r\nsub_clubname : uuuu\r\nisactive : True\r\ncreate_date : 8/21/2018 4:56:44 PM\r\ncreate_admin : 1\r\n', 0, 'admin', '::1'),
(200, 'Insert', '2018-08-23 09:37:22', 'Add Club', 'Created new data are as follow:\r\nclubid : 22\r\nclubname : MMA\r\nteam_manager : Myo Myo\r\nphone : 09348344\r\nemail : gg@gmail.com\r\naddress : Yangon\r\nlogo : \r\nisactive : True\r\ncreatedate : 8/23/2018 9:37:21 AM\r\ncreateuser : 1\r\n', 0, 'admin', '::1'),
(201, 'Delete', '2018-08-23 10:18:04', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 53\r\nplayerid : 44\r\nattachfilename : 53.png\r\n', 0, 'admin', '::1'),
(202, 'Delete', '2018-08-23 10:23:09', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 76\r\nplayerid : 43\r\nattachfilename : 76.png\r\n', 0, 'admin', '::1'),
(203, 'Insert', '2018-08-23 11:15:41', 'Add Club', 'Created new data are as follow:\r\nclubid : 23\r\nclubname : MGU\r\nteam_manager : U Hla\r\nphone : 03949834\r\nemail : hla@gmail.com\r\naddress : Magwe\r\nlogo : \r\nisactive : True\r\ncreatedate : 8/23/2018 11:15:40 AM\r\ncreateuser : 1\r\n', 0, 'admin', '::1'),
(204, 'Delete', '2018-08-23 11:16:34', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 9\r\nclubid : 23\r\nattachfilename : 9.jpg\r\n', 0, 'admin', '::1'),
(205, 'Insert', '2018-08-23 11:42:21', 'Add Admin', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Jok\r\ncreated_date : 8/23/2018 11:42:12 AM\r\nEmail : jok@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : Jok\r\nmodified_date : 8/23/2018 11:42:13 AM\r\nPassword : Y5GLnb2wNBhRMKOAdENzHjIDlRqWppMF\r\nSalt : X3c4QSt3OOlx1VlypqFHCoIQO8UpT77r\r\n', 0, 'admin', '::1'),
(206, 'Delete', '2018-08-23 11:45:36', 'Delete Admin', 'Deleted old data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Jok\r\ncreated_date : 8/23/2018 11:42:12 AM\r\nEmail : jok@gmail.com\r\nImagePath : 6.jpg\r\nlogin_fail_count : 0\r\nLoginName : Jok\r\nmodified_date : 8/23/2018 11:42:13 AM\r\nPassword : Y5GLnb2wNBhRMKOAdENzHjIDlRqWppMF\r\nSalt : X3c4QSt3OOlx1VlypqFHCoIQO8UpT77r\r\n', 0, 'admin', '::1'),
(207, 'Insert', '2018-08-23 12:13:38', 'Add Player', 'Created new data are as follow:\r\nplayerid : 48\r\nenroll_number : 03898\r\nHPDTid : \r\nplayer_name : Jin\r\ngender : True\r\naddress : ygn\r\nnrc : 3434jfsda\r\npassport : 454657y\r\nafcid : \r\nposition : 3\r\nnationality : 12\r\nprimary_player_category : 8\r\nsecondary_player_category : 7\r\ndateofbirth : 5/6/2001 12:00:00 AM\r\nphoto :  \r\nisactive : True\r\ncreatedate : 8/23/2018 12:13:37 PM\r\ncreateuser : 1\r\n', 0, 'admin', '::1'),
(208, 'Update', '2018-08-23 12:59:44', 'Update Player', 'Updated data are as follow:\r\nafcid :  >>> 37847h\r\ncreatedate : 8/23/2018 12:13:37 PM >>> 8/23/2018 12:59:44 PM\r\n', 0, 'admin', '::1'),
(209, 'Delete', '2018-08-23 13:38:37', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 7\r\nplayer_clubid : 3\r\nattachfilename : 7.png\r\n', 0, 'admin', '::1'),
(210, 'Update', '2018-08-23 13:39:11', 'Update Player Club', 'Updated data are as follow:\r\ncreatedate : 8/20/2018 4:08:42 PM >>> 8/23/2018 1:39:10 PM\r\n', 0, 'admin', '::1'),
(211, 'Update', '2018-08-23 13:43:21', 'Update Club', 'Updated data are as follow:\r\nisactive : True >>> False\r\n', 0, 'admin', '::1'),
(212, 'Delete', '2018-08-23 13:43:23', 'Delete SubClub', 'Deleted old data are as follow:\r\nsub_clubid : 6\r\nclubid : 7\r\nsub_clubname : Chin1\r\nisactive : True\r\ncreate_date : 8/13/2018 5:18:49 PM\r\ncreate_admin : 1\r\n', 0, 'admin', '::1'),
(213, 'Delete', '2018-08-23 13:43:25', 'Delete SubClub', 'Deleted old data are as follow:\r\nsub_clubid : 7\r\nclubid : 7\r\nsub_clubname : Chin 2\r\nisactive : True\r\ncreate_date : 8/13/2018 5:18:57 PM\r\ncreate_admin : 1\r\n', 0, 'admin', '::1'),
(214, 'Insert', '2018-08-23 15:19:00', 'Add Player Club', 'Created new data are as follow:\r\nplayer_clubid : 7\r\nplayerid : 32\r\nsub_clubid : \r\nclubid : 23\r\njoin_date : 8/23/2018 12:00:00 AM\r\nend_date : 10/31/2020 12:00:00 AM\r\ncreatedate : 8/23/2018 3:18:41 PM\r\ncreateuser : 1\r\nisactive : True\r\n', 0, 'admin', '::1'),
(215, 'Insert', '2018-08-23 15:51:39', 'Add Player Club', 'Created new data are as follow:\r\nplayer_clubid : 8\r\nplayerid : 25\r\nsub_clubid : \r\nclubid : 9\r\njoin_date : 8/23/2018 12:00:00 AM\r\nend_date : 1/30/2021 12:00:00 AM\r\ncreatedate : 8/23/2018 3:51:38 PM\r\ncreateuser : 1\r\nisactive : True\r\n', 0, 'admin', '::1'),
(216, 'Insert', '2018-08-23 17:16:36', 'Add Player Club', 'Created new data are as follow:\r\nplayer_clubid : 13\r\nplayerid : 45\r\nsub_clubid : 11\r\nclubid : 22\r\njoin_date : 8/23/2018 12:00:00 AM\r\nend_date : 8/31/2019 12:00:00 AM\r\ncreatedate : 8/23/2018 5:16:35 PM\r\ncreateuser : 1\r\nisactive : True\r\n', 0, 'admin', '::1'),
(217, 'Update', '2018-08-24 10:25:56', 'Update Player Club', 'Updated data are as follow:\r\nend_date : 8/31/2019 12:00:00 AM >>> 10/31/2018 12:00:00 AM\r\n', 0, 'admin', '::1'),
(218, 'Update', '2018-08-24 11:23:46', 'Update Player Club', 'Updated data are as follow:\r\nend_date : 3/31/2020 12:00:00 AM >>> 8/24/2018 12:00:00 AM\r\n', 0, 'admin', '::1'),
(219, 'Insert', '2018-08-24 11:49:38', 'Add Player Club', 'Created new data are as follow:\r\nplayer_clubid : 14\r\nplayerid : 44\r\nsub_clubid : 11\r\nclubid : 22\r\njoin_date : 8/24/2018 12:00:00 AM\r\nend_date : 8/31/2019 12:00:00 AM\r\ncreatedate : 8/24/2018 11:49:37 AM\r\ncreateuser : 1\r\nisactive : True\r\n', 0, 'admin', '::1'),
(220, 'Insert', '2018-08-27 09:32:24', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 08/02/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 07/11/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(221, 'Insert', '2018-08-27 11:14:54', 'Update Player Club', 'Created new data are as follow:\r\nplayer_clubid : 13\r\nplayerid : 47\r\nsub_clubid : 10\r\nclubid : 9\r\njoin_date : 8/27/2018 12:00:00 AM\r\nend_date : 1/31/2020 12:00:00 AM\r\ncreatedate : 8/27/2018 11:14:53 AM\r\ncreateuser : 1\r\nisactive : True\r\n', 0, 'admin', '::1'),
(222, 'Insert', '2018-08-27 11:25:51', 'Update Player Club', 'Created new data are as follow:\r\nplayer_clubid : 14\r\nplayerid : 45\r\nsub_clubid : 10\r\nclubid : 9\r\njoin_date : 8/27/2018 12:00:00 AM\r\nend_date : 8/31/2019 12:00:00 AM\r\ncreatedate : 8/27/2018 11:25:50 AM\r\ncreateuser : 1\r\nisactive : True\r\n', 0, 'admin', '::1'),
(223, 'Insert', '2018-08-27 11:30:02', 'Update Player Club', 'Created new data are as follow:\r\nplayer_clubid : 15\r\nplayerid : 43\r\nsub_clubid : 10\r\nclubid : 9\r\njoin_date : 8/27/2018 12:00:00 AM\r\nend_date : 8/27/2020 12:00:00 AM\r\ncreatedate : 8/27/2018 11:30:01 AM\r\ncreateuser : 1\r\nisactive : True\r\n', 0, 'admin', '::1'),
(224, 'Update', '2018-08-27 14:43:54', 'Update Player Club', 'Updated data are as follow:\r\nend_date : 8/31/2019 12:00:00 AM >>> 8/27/2018 12:00:00 AM\r\n', 0, 'admin', '::1'),
(225, 'Update', '2018-08-27 14:46:28', 'Update Player Club', 'Updated data are as follow:\r\nend_date : 10/31/2018 12:00:00 AM >>> 8/27/2018 12:00:00 AM\r\n', 0, 'admin', '::1'),
(226, 'Update', '2018-08-27 14:49:34', 'Update Player Club', 'Updated data are as follow:\r\nend_date : 8/31/2019 12:00:00 AM >>> 8/27/2018 12:00:00 AM\r\n', 0, 'admin', '::1'),
(227, 'Update', '2018-08-27 14:50:35', 'Update Player Club', 'Updated data are as follow:\r\nend_date : 1/31/2020 12:00:00 AM >>> 8/28/2018 12:00:00 AM\r\n', 0, 'admin', '::1'),
(228, 'Insert', '2018-08-27 17:01:14', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 08/02/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 07/11/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(229, 'Insert', '2018-08-27 17:01:38', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(230, 'Update', '2018-08-27 17:04:10', 'Update Admin Level', 'Updated data are as follow:\r\nmodified_date : 8/1/2018 1:09:55 PM >>> 8/27/2018 5:04:09 PM\r\n', 0, 'admin', '::1'),
(231, 'Insert', '2018-08-27 17:09:30', 'Add Admin Level', 'Created new data are as follow:\r\nAdminLevelID : 3\r\nAdminLevel : pont\r\ncreated_date : 8/27/2018 5:09:29 PM\r\nDescription : aa\r\nIsAdministrator : False\r\nmodified_date : 8/27/2018 5:09:29 PM\r\nRemark : aa\r\nrestricted_iplist : aa\r\n', 0, 'admin', '::1'),
(232, 'Insert', '2018-08-27 17:15:05', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(233, 'Insert', '2018-08-27 17:15:55', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(234, 'Insert', '2018-08-27 17:16:36', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(235, 'Insert', '2018-08-27 17:17:07', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(236, 'Insert', '2018-08-27 17:18:35', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(237, 'Insert', '2018-08-28 09:02:46', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 08/02/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 07/11/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(238, 'Insert', '2018-08-28 09:15:06', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(239, 'Insert', '2018-08-28 09:15:48', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(240, 'Insert', '2018-08-28 09:17:19', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(241, 'Insert', '2018-08-28 09:37:49', 'Add Admin', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 3\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 0, 'admin', '::1'),
(242, 'Insert', '2018-08-28 09:38:09', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 3\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 6, 'admin', '127.0.0.1'),
(243, 'Insert', '2018-08-28 09:38:27', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(244, 'Insert', '2018-08-28 09:39:01', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 3\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 6, 'admin', '127.0.0.1'),
(245, 'Insert', '2018-08-28 09:42:23', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 3\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 6, 'admin', '127.0.0.1'),
(246, 'Insert', '2018-08-28 09:46:39', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(247, 'Update', '2018-08-28 09:53:44', 'Update Admin', 'Updated data are as follow:\r\nAdminLevelID : 1 >>> 3\r\n', 0, 'admin', '::1'),
(248, 'Insert', '2018-08-28 09:57:44', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 08/02/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 07/11/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(249, 'Insert', '2018-08-28 10:03:28', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(250, 'Update', '2018-08-28 10:05:46', 'Update Admin Level', 'Updated data are as follow:\r\nmodified_date : 8/27/2018 5:09:29 PM >>> 8/28/2018 10:05:45 AM\r\nrestricted_iplist : aa >>> \r\n', 0, 'admin', '::1'),
(251, 'Insert', '2018-08-28 10:05:47', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 3\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 6, 'admin', '127.0.0.1'),
(252, 'Insert', '2018-08-28 10:06:22', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(253, 'Insert', '2018-08-28 10:07:33', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 3\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 6, 'admin', '127.0.0.1'),
(254, 'Insert', '2018-08-28 11:06:11', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(255, 'Update', '2018-08-28 11:07:21', 'Update Admin Level', 'Updated data are as follow:\r\nmodified_date : 8/28/2018 10:05:45 AM >>> 8/28/2018 11:07:20 AM\r\n', 0, 'admin', '::1'),
(256, 'Update', '2018-08-28 11:10:12', 'Update Admin Level', 'Updated data are as follow:\r\nmodified_date : 8/28/2018 11:07:20 AM >>> 8/28/2018 11:10:11 AM\r\n', 0, 'admin', '::1'),
(257, 'Insert', '2018-08-28 11:10:44', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 3\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 6, 'admin', '127.0.0.1'),
(258, 'Insert', '2018-08-28 11:43:25', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(259, 'Insert', '2018-08-28 13:37:31', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 3\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 6, 'admin', '127.0.0.1'),
(260, 'Insert', '2018-08-28 13:43:32', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 3\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 6, 'admin', '127.0.0.1'),
(261, 'Delete', '2018-08-28 14:11:23', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 91\r\nplayerid : 45\r\nattachfilename : 91.txt\r\n', 0, 'admin', '::1'),
(262, 'Delete', '2018-08-28 14:13:54', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 81\r\nplayerid : 45\r\nattachfilename : 81.txt\r\n', 0, 'admin', '::1'),
(263, 'Delete', '2018-08-28 14:31:46', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 94\r\nplayerid : 45\r\nattachfilename : 94.txt\r\n', 0, 'admin', '::1'),
(264, 'Delete', '2018-08-28 14:40:27', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 95\r\nplayerid : 45\r\nattachfilename : 95.txt\r\n', 0, 'admin', '::1'),
(265, 'Delete', '2018-08-28 15:27:53', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 101\r\nplayerid : 45\r\nattachfilename : 101.txt\r\n', 0, 'admin', '::1'),
(266, 'Delete', '2018-08-28 15:28:10', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 100\r\nplayerid : 45\r\nattachfilename : 100[\r\n  \".txt\"\r\n]\r\n', 0, 'admin', '::1'),
(267, 'Delete', '2018-08-28 15:28:17', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 99\r\nplayerid : 45\r\nattachfilename : 99.txt\r\n', 0, 'admin', '::1'),
(268, 'Delete', '2018-08-28 15:28:26', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 92\r\nplayerid : 45\r\nattachfilename : 92.txt\r\n', 0, 'admin', '::1'),
(269, 'Insert', '2018-08-28 15:36:08', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 3\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 6, 'admin', '127.0.0.1'),
(270, 'Delete', '2018-08-28 16:14:48', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 109\r\nplayerid : 45\r\nattachfilename : 109.txt\r\n', 0, 'admin', '::1'),
(271, 'Delete', '2018-08-28 16:17:42', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 108\r\nplayerid : 45\r\nattachfilename : 108.txt\r\n', 0, 'admin', '::1'),
(272, 'Delete', '2018-08-28 16:21:31', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 107\r\nplayerid : 45\r\nattachfilename : 107.txt\r\n', 0, 'admin', '::1'),
(273, 'Delete', '2018-08-28 16:26:31', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 106\r\nplayerid : 45\r\nattachfilename : 106.txt\r\n', 0, 'admin', '::1'),
(274, 'Delete', '2018-08-28 16:32:52', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 105\r\nplayerid : 45\r\nattachfilename : 105.txt\r\n', 0, 'admin', '::1'),
(275, 'Insert', '2018-08-28 17:06:49', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 3\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 6, 'admin', '127.0.0.1'),
(276, 'Delete', '2018-08-28 17:07:06', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 104\r\nplayerid : 45\r\nattachfilename : 104.txt\r\n', 0, 'admin', '::1'),
(277, 'Insert', '2018-08-28 17:08:11', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 3\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 6, 'admin', '127.0.0.1'),
(278, 'Delete', '2018-08-28 17:08:28', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 103\r\nplayerid : 45\r\nattachfilename : 103.txt\r\n', 0, 'admin', '::1'),
(279, 'Delete', '2018-08-28 17:10:08', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 102\r\nplayerid : 45\r\nattachfilename : 102.txt\r\n', 0, 'admin', '::1'),
(280, 'Insert', '2018-08-28 17:14:34', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 3\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 6, 'admin', '127.0.0.1'),
(281, 'Insert', '2018-08-28 17:17:20', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 08/02/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 07/11/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(282, 'Insert', '2018-08-28 17:23:25', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 3\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 6, 'admin', '127.0.0.1'),
(283, 'Insert', '2018-08-28 17:55:36', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 08/02/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 07/11/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(284, 'Delete', '2018-08-28 17:57:54', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 120\r\nplayerid : 48\r\nattachfilename : 120.txt\r\n', 0, 'admin', '::1'),
(285, 'Delete', '2018-08-28 17:59:13', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 121\r\nplayerid : 48\r\nattachfilename : 121.txt\r\n', 0, 'admin', '::1'),
(286, 'Delete', '2018-08-28 18:04:18', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 119\r\nplayerid : 48\r\nattachfilename : 119.txt\r\n', 0, 'admin', '::1'),
(287, 'Delete', '2018-08-28 18:07:32', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 118\r\nplayerid : 48\r\nattachfilename : 118.txt\r\n', 0, 'admin', '::1'),
(288, 'Delete', '2018-08-28 18:08:04', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 117\r\nplayerid : 48\r\nattachfilename : 117.txt\r\n', 0, 'admin', '::1'),
(289, 'Delete', '2018-08-28 18:09:47', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 116\r\nplayerid : 48\r\nattachfilename : 116.txt\r\n', 0, 'admin', '::1'),
(290, 'Delete', '2018-08-28 18:09:55', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 115\r\nplayerid : 48\r\nattachfilename : 115.txt\r\n', 0, 'admin', '::1'),
(291, 'Delete', '2018-08-28 18:13:45', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 123\r\nplayerid : 48\r\nattachfilename : 123.txt\r\n', 0, 'admin', '::1'),
(292, 'Delete', '2018-08-28 18:13:50', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 122\r\nplayerid : 48\r\nattachfilename : 122.txt\r\n', 0, 'admin', '::1'),
(293, 'Delete', '2018-08-28 18:23:17', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 127\r\nplayerid : 48\r\nattachfilename : 127.PNG\r\n', 0, 'admin', '::1'),
(294, 'Delete', '2018-08-28 18:24:21', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 128\r\nplayerid : 48\r\nattachfilename : 128.jpg\r\n', 0, 'admin', '::1'),
(295, 'Delete', '2018-08-28 18:24:33', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 126\r\nplayerid : 48\r\nattachfilename : 126.jpg\r\n', 0, 'admin', '::1'),
(296, 'Delete', '2018-08-28 18:24:42', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 125\r\nplayerid : 48\r\nattachfilename : 125.txt\r\n', 0, 'admin', '::1'),
(297, 'Delete', '2018-08-28 18:29:44', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 130\r\nplayerid : 48\r\nattachfilename : 130.jpg\r\n', 0, 'admin', '::1'),
(298, 'Delete', '2018-08-28 18:29:52', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 129\r\nplayerid : 48\r\nattachfilename : 129.jpg\r\n', 0, 'admin', '::1'),
(299, 'Delete', '2018-08-28 18:29:59', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 124\r\nplayerid : 48\r\nattachfilename : 124.txt\r\n', 0, 'admin', '::1'),
(300, 'Insert', '2018-08-28 18:42:04', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 08/02/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 07/11/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(301, 'Delete', '2018-08-28 18:45:05', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 136\r\nplayerid : 48\r\nattachfilename : 136.jpg\r\n', 0, 'admin', '::1'),
(302, 'Insert', '2018-08-28 18:47:41', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 08/02/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 07/11/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(303, 'Delete', '2018-08-28 18:49:46', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 138\r\nplayerid : 48\r\nattachfilename : 138.jpg\r\n', 0, 'admin', '::1');
INSERT INTO `tbl_eventlog` (`ID`, `LogType`, `LogDateTime`, `Source`, `LogMessage`, `UserID`, `UserType`, `ipAddress`) VALUES
(304, 'Delete', '2018-08-28 18:49:54', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 139\r\nplayerid : 48\r\nattachfilename : 139.jpg\r\n', 0, 'admin', '::1'),
(305, 'Delete', '2018-08-28 18:50:02', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 137\r\nplayerid : 48\r\nattachfilename : 137.jpg\r\n', 0, 'admin', '::1'),
(306, 'Delete', '2018-08-28 18:50:10', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 135\r\nplayerid : 48\r\nattachfilename : 135.PNG\r\n', 0, 'admin', '::1'),
(307, 'Delete', '2018-08-28 18:50:17', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 134\r\nplayerid : 48\r\nattachfilename : 134.txt\r\n', 0, 'admin', '::1'),
(308, 'Delete', '2018-08-28 18:50:25', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 133\r\nplayerid : 48\r\nattachfilename : 133.PNG\r\n', 0, 'admin', '::1'),
(309, 'Insert', '2018-08-28 18:52:50', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 08/02/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 07/11/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(310, 'Delete', '2018-08-28 19:05:37', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 146\r\nplayerid : 46\r\nattachfilename : 146.jpg\r\n', 0, 'admin', '::1'),
(311, 'Insert', '2018-08-29 10:22:05', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(312, 'Insert', '2018-08-29 10:25:59', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 3\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 6, 'admin', '127.0.0.1'),
(313, 'Insert', '2018-08-29 10:51:56', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 3\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 6, 'admin', '127.0.0.1'),
(314, 'Insert', '2018-08-29 11:11:58', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 3\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 6, 'admin', '127.0.0.1'),
(315, 'Insert', '2018-08-29 11:13:47', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 3\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 6, 'admin', '127.0.0.1'),
(316, 'Insert', '2018-08-29 11:15:13', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 3\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 6, 'admin', '127.0.0.1'),
(317, 'Insert', '2018-08-29 11:17:14', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 3\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 6, 'admin', '127.0.0.1'),
(318, 'Insert', '2018-08-29 11:21:45', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 3\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 6, 'admin', '127.0.0.1'),
(319, 'Insert', '2018-08-29 11:23:17', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 3\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 6, 'admin', '127.0.0.1'),
(320, 'Insert', '2018-08-29 11:28:22', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 3\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 6, 'admin', '127.0.0.1'),
(321, 'Insert', '2018-08-29 11:37:04', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 3\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 6, 'admin', '127.0.0.1'),
(322, 'Insert', '2018-08-29 11:41:47', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 3\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 6, 'admin', '127.0.0.1'),
(323, 'Insert', '2018-08-29 11:56:44', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 3\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 6, 'admin', '127.0.0.1'),
(324, 'Insert', '2018-08-29 11:59:06', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 3\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 6, 'admin', '127.0.0.1'),
(325, 'Insert', '2018-08-29 12:00:47', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 3\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 6, 'admin', '127.0.0.1'),
(326, 'Insert', '2018-08-29 13:15:42', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 3\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 6, 'admin', '127.0.0.1'),
(327, 'Insert', '2018-08-29 13:22:06', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(328, 'Insert', '2018-08-29 13:24:26', 'Add Admin Level', 'Created new data are as follow:\r\nAdminLevelID : 4\r\nAdminLevel : user\r\ncreated_date : 8/29/2018 1:24:25 PM\r\nDescription : a\r\nIsAdministrator : False\r\nmodified_date : 8/29/2018 1:24:25 PM\r\nRemark : \r\nrestricted_iplist : \r\n', 0, 'admin', '::1'),
(329, 'Update', '2018-08-29 13:26:35', 'Update Admin Level', 'Updated data are as follow:\r\nmodified_date : 8/29/2018 1:24:25 PM >>> 8/29/2018 1:26:34 PM\r\n', 0, 'admin', '::1'),
(330, 'Insert', '2018-08-29 14:08:32', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 3\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 6, 'admin', '127.0.0.1'),
(331, 'Insert', '2018-08-29 14:10:48', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 3\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 6, 'admin', '127.0.0.1'),
(332, 'Insert', '2018-08-29 14:26:06', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 3\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 6, 'admin', '127.0.0.1'),
(333, 'Insert', '2018-08-29 14:26:48', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 3\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 6, 'admin', '127.0.0.1'),
(334, 'Insert', '2018-08-29 14:27:35', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 3\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 6, 'admin', '127.0.0.1'),
(335, 'Insert', '2018-08-29 14:27:45', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 08/02/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 07/11/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(336, 'Insert', '2018-08-29 14:27:59', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 08/02/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 07/11/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(337, 'Insert', '2018-08-29 14:28:49', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 3\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 6, 'admin', '127.0.0.1'),
(338, 'Insert', '2018-08-29 14:32:42', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 3\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 6, 'admin', '127.0.0.1'),
(339, 'Insert', '2018-08-29 14:34:53', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 3\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 6, 'admin', '127.0.0.1'),
(340, 'Insert', '2018-08-29 14:36:19', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 3\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 6, 'admin', '127.0.0.1'),
(341, 'Insert', '2018-08-29 14:38:47', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 3\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 6, 'admin', '127.0.0.1'),
(342, 'Delete', '2018-08-29 14:41:02', 'Delete Player', 'Deleted old data are as follow:\r\nplayerid : 38\r\nenroll_number : 88990\r\nHPDTid : \r\nplayer_name : ttr\r\ngender : False\r\naddress : tty\r\nnrc : 5tty77\r\npassport : 45656\r\nafcid : \r\nposition : 6\r\nnationality : 4\r\nprimary_player_category : 8\r\nsecondary_player_category : 7\r\ndateofbirth : 8/5/2018 12:00:00 AM\r\nphoto : 38.jpg\r\nisactive : False\r\ncreatedate : 8/16/2018 3:44:07 PM\r\ncreateuser : 1\r\n', 0, 'admin', '::1'),
(343, 'Insert', '2018-08-29 14:42:36', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(344, 'Update', '2018-08-29 14:43:34', 'Update Admin Level', 'Updated data are as follow:\r\nmodified_date : 8/29/2018 1:26:34 PM >>> 8/29/2018 2:43:33 PM\r\n', 0, 'admin', '::1'),
(345, 'Update', '2018-08-29 14:44:44', 'Update Admin', 'Updated data are as follow:\r\nAdminLevelID : 3 >>> 4\r\n', 0, 'admin', '::1'),
(346, 'Insert', '2018-08-29 14:46:16', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 6\r\naccess_status : 0\r\nAdminLevelID : 4\r\nAdminName : popo\r\ncreated_date : 8/28/2018 9:37:47 AM\r\nEmail : soepapaoo22@gmail.com\r\nImagePath : \r\nlogin_fail_count : 0\r\nLoginName : popo1\r\nmodified_date : 8/28/2018 9:37:47 AM\r\nPassword : ifg/qpVoRkJ2kh4+3xhf0ixzrn+mi3cZ\r\nSalt : 6mXXLW+fTnD6gqit5TEDgUy0/yxLbHbF\r\n', 6, 'admin', '127.0.0.1'),
(347, 'Insert', '2018-08-29 14:54:53', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(348, 'Insert', '2018-08-29 15:24:01', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 08/02/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 07/11/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(349, 'Insert', '2018-08-29 16:18:18', 'Add Player', 'Created new data are as follow:\r\nplayerid : 49\r\nenroll_number : 43431\r\nHPDTid : HPDT/000003/2018\r\nplayer_name : htoo\r\ngender : True\r\naddress : ygn\r\nnrc : 12/er738\r\npassport : err343er43\r\nafcid : \r\nposition : 5\r\nnationality : 4\r\nprimary_player_category : 10\r\nsecondary_player_category : 7\r\ndateofbirth : 10/25/2005 12:00:00 AM\r\nphoto :  \r\nisactive : True\r\ncreatedate : 8/29/2018 4:18:07 PM\r\ncreateuser : 1\r\n', 0, 'admin', '::1'),
(350, 'Insert', '2019-08-29 16:21:32', 'Add Player', 'Created new data are as follow:\r\nplayerid : 50\r\nenroll_number : 654765\r\nHPDTid : HPDT/000001/2019\r\nplayer_name : Gugu\r\ngender : False\r\naddress : Yangon\r\nnrc : 3/ejr73728\r\npassport : r434356\r\nafcid : \r\nposition : 3\r\nnationality : 12\r\nprimary_player_category : 9\r\nsecondary_player_category : 10\r\ndateofbirth : 3/14/2006 12:00:00 AM\r\nphoto :  \r\nisactive : True\r\ncreatedate : 8/29/2019 4:21:31 PM\r\ncreateuser : 1\r\n', 0, 'admin', '::1'),
(351, 'Insert', '2018-08-29 17:05:33', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 08/02/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 07/11/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(352, 'Insert', '2018-08-29 17:05:59', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 08/02/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 07/11/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(353, 'Insert', '2018-08-29 17:06:19', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 08/02/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 07/11/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(354, 'Insert', '2018-08-29 17:12:43', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 08/02/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 07/11/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(355, 'Insert', '2018-08-29 17:15:17', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 08/02/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 07/11/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(356, 'Insert', '2018-08-29 17:16:24', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 08/02/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 07/11/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(357, 'Insert', '2018-08-29 17:28:08', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 08/02/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 07/11/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(358, 'Insert', '2018-08-29 17:30:46', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 08/02/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 07/11/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(359, 'Insert', '2018-08-29 17:31:11', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 08/02/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 07/11/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(360, 'Insert', '2018-08-30 11:45:05', 'Add FingetTemplate', 'Created new data are as follow:\r\ntemplateid : 0\r\nplayerid : 49\r\nfingerid : 1\r\nfingertemplate : System.Byte[]\r\nmodified_date : 8/30/2018 11:44:58 AM\r\n', 0, 'admin', '::1'),
(361, 'Insert', '2018-08-30 11:45:11', 'Add FingetTemplate', 'Created new data are as follow:\r\ntemplateid : 0\r\nplayerid : 49\r\nfingerid : 2\r\nfingertemplate : System.Byte[]\r\nmodified_date : 8/30/2018 11:45:09 AM\r\n', 0, 'admin', '::1'),
(362, 'Insert', '2018-08-30 11:45:16', 'Add FingetTemplate', 'Created new data are as follow:\r\ntemplateid : 0\r\nplayerid : 49\r\nfingerid : 3\r\nfingertemplate : System.Byte[]\r\nmodified_date : 8/30/2018 11:45:14 AM\r\n', 0, 'admin', '::1'),
(363, 'Insert', '2018-08-30 11:49:32', 'Add FingetTemplate', 'Created new data are as follow:\r\ntemplateid : 0\r\nplayerid : 49\r\nfingerid : 1\r\nfingertemplate : fwqywuyhejei\r\nmodified_date : 8/30/2018 11:49:23 AM\r\n', 0, 'admin', '::1'),
(364, 'Insert', '2018-08-30 11:49:43', 'Add FingetTemplate', 'Created new data are as follow:\r\ntemplateid : 0\r\nplayerid : 49\r\nfingerid : 2\r\nfingertemplate : hefuiwehhshf\r\nmodified_date : 8/30/2018 11:49:41 AM\r\n', 0, 'admin', '::1'),
(365, 'Insert', '2018-08-30 11:49:51', 'Add FingetTemplate', 'Created new data are as follow:\r\ntemplateid : 0\r\nplayerid : 49\r\nfingerid : 3\r\nfingertemplate : rfheuijeijfc\r\nmodified_date : 8/30/2018 11:49:48 AM\r\n', 0, 'admin', '::1'),
(366, 'Insert', '2018-08-30 11:49:58', 'Add FingetTemplate', 'Created new data are as follow:\r\ntemplateid : 0\r\nplayerid : 49\r\nfingerid : 4\r\nfingertemplate : 2377hfdhfdf\r\nmodified_date : 8/30/2018 11:49:55 AM\r\n', 0, 'admin', '::1'),
(367, 'Insert', '2018-08-30 11:50:05', 'Add FingetTemplate', 'Created new data are as follow:\r\ntemplateid : 0\r\nplayerid : 49\r\nfingerid : 5\r\nfingertemplate : dfeir938908\r\nmodified_date : 8/30/2018 11:50:02 AM\r\n', 0, 'admin', '::1'),
(368, 'Update', '2018-08-30 13:44:52', 'Update FingetTemplate', 'Updated data are as follow:\r\nmodified_date : 8/30/2018 11:49:23 AM >>> 8/30/2018 1:44:44 PM\r\n', 0, 'admin', '::1'),
(369, 'Update', '2018-08-30 13:45:13', 'Update FingetTemplate', 'Updated data are as follow:\r\nmodified_date : 8/30/2018 11:49:41 AM >>> 8/30/2018 1:45:11 PM\r\n', 0, 'admin', '::1'),
(370, 'Update', '2018-08-30 13:45:20', 'Update FingetTemplate', 'Updated data are as follow:\r\nmodified_date : 8/30/2018 11:49:48 AM >>> 8/30/2018 1:45:19 PM\r\n', 0, 'admin', '::1'),
(371, 'Update', '2018-08-30 13:52:29', 'Update FingetTemplate', 'Updated data are as follow:\r\nmodified_date : 8/30/2018 1:44:44 PM >>> 8/30/2018 1:52:27 PM\r\n', 0, 'admin', '::1'),
(372, 'Update', '2018-08-30 13:52:55', 'Update FingetTemplate', 'Updated data are as follow:\r\nmodified_date : 8/30/2018 1:45:11 PM >>> 8/30/2018 1:52:53 PM\r\n', 0, 'admin', '::1'),
(373, 'Update', '2018-08-30 13:53:03', 'Update FingetTemplate', 'Updated data are as follow:\r\nmodified_date : 8/30/2018 1:45:19 PM >>> 8/30/2018 1:53:02 PM\r\n', 0, 'admin', '::1'),
(374, 'Update', '2018-08-30 13:57:03', 'Update FingetTemplate', 'Updated data are as follow:\r\nmodified_date : 8/30/2018 1:52:27 PM >>> 8/30/2018 1:57:01 PM\r\n', 0, 'admin', '::1'),
(375, 'Update', '2018-08-30 13:57:51', 'Update FingetTemplate', 'Updated data are as follow:\r\nmodified_date : 8/30/2018 1:57:01 PM >>> 8/30/2018 1:57:48 PM\r\n', 0, 'admin', '::1'),
(376, 'Update', '2018-08-30 14:01:19', 'Update FingetTemplate', 'Updated data are as follow:\r\nmodified_date : 8/30/2018 1:57:48 PM >>> 8/30/2018 2:01:18 PM\r\n', 0, 'admin', '::1'),
(377, 'Update', '2018-08-30 14:04:22', 'Update FingetTemplate', 'Updated data are as follow:\r\nmodified_date : 8/30/2018 2:01:18 PM >>> 8/30/2018 2:04:20 PM\r\n', 0, 'admin', '::1'),
(378, 'Insert', '2018-08-30 14:23:57', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(379, 'Insert', '2018-08-30 14:27:32', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(380, 'Insert', '2018-08-30 14:28:36', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(381, 'Update', '2018-08-30 14:28:55', 'Update FingetTemplate', 'Updated data are as follow:\r\nmodified_date : 8/30/2018 1:52:53 PM >>> 8/30/2018 2:28:52 PM\r\n', 0, 'admin', '::1'),
(382, 'Insert', '2018-08-30 14:29:02', 'Add FingetTemplate', 'Created new data are as follow:\r\ntemplateid : 13\r\nplayerid : 49\r\nfingerid : 6\r\nfingertemplate : System.Byte[]\r\nmodified_date : 8/30/2018 2:29:00 PM\r\n', 0, 'admin', '::1'),
(383, 'Insert', '2018-08-30 14:43:50', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(384, 'Insert', '2018-08-30 14:47:57', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(385, 'Insert', '2018-08-30 14:53:10', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(386, 'Insert', '2018-08-30 14:54:21', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(387, 'Delete', '2018-08-30 15:01:53', 'Delete Template', 'Deleted old data are as follow:\r\ntemplateid : 12\r\nplayerid : 49\r\nfingerid : 5\r\nfingertemplate : System.Byte[]\r\nmodified_date : 8/30/2018 11:50:02 AM\r\n', 0, 'admin', '::1'),
(388, 'Insert', '2018-08-30 15:02:05', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(389, 'Insert', '2018-08-30 15:04:51', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(390, 'Insert', '2018-08-30 15:05:42', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(391, 'Insert', '2018-08-30 15:08:44', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(392, 'Insert', '2018-08-30 15:16:20', 'Add FingetTemplate', 'Created new data are as follow:\r\ntemplateid : 14\r\nplayerid : 48\r\nfingerid : 1\r\nfingertemplate : System.Byte[]\r\nmodified_date : 8/30/2018 3:16:15 PM\r\n', 0, 'admin', '::1'),
(393, 'Insert', '2018-08-30 15:20:23', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(394, 'Insert', '2018-08-30 15:21:18', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(395, 'Delete', '2018-08-30 15:47:18', 'Delete Template', 'Deleted old data are as follow:\r\ntemplateid : 10\r\nplayerid : 49\r\nfingerid : 3\r\nfingertemplate : System.Byte[]\r\nmodified_date : 8/30/2018 1:53:02 PM\r\n', 0, 'admin', '::1'),
(396, 'Insert', '2018-08-30 16:30:01', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(397, 'Insert', '2018-08-31 09:23:22', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(398, 'Insert', '2018-08-31 09:24:19', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(399, 'Insert', '2018-08-31 09:29:36', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(400, 'Insert', '2018-08-31 09:30:20', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(401, 'Insert', '2018-08-31 09:32:41', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(402, 'Insert', '2018-08-31 09:34:24', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(403, 'Insert', '2018-08-31 09:37:19', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(404, 'Insert', '2018-08-31 09:42:06', 'Add FingetTemplate', 'Created new data are as follow:\r\ntemplateid : 15\r\nplayerid : 48\r\nfingerid : 2\r\nfingertemplate : System.Byte[]\r\nmodified_date : 8/31/2018 9:42:02 AM\r\n', 0, 'admin', '::1'),
(405, 'Insert', '2018-08-31 09:42:27', 'Add FingetTemplate', 'Created new data are as follow:\r\ntemplateid : 16\r\nplayerid : 48\r\nfingerid : 3\r\nfingertemplate : System.Byte[]\r\nmodified_date : 8/31/2018 9:42:24 AM\r\n', 0, 'admin', '::1'),
(406, 'Insert', '2018-08-31 09:45:00', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(407, 'Insert', '2018-08-31 09:46:11', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(408, 'Insert', '2018-08-31 09:48:22', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(409, 'Insert', '2018-08-31 09:49:47', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(410, 'Insert', '2018-08-31 09:55:13', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(411, 'Insert', '2018-08-31 10:01:18', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(412, 'Insert', '2018-08-31 11:02:41', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(413, 'Insert', '2018-08-31 11:06:16', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(414, 'Insert', '2018-08-31 11:23:19', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(415, 'Insert', '2018-08-31 11:25:44', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(416, 'Insert', '2018-08-31 11:26:26', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(417, 'Insert', '2018-08-31 11:31:01', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(418, 'Insert', '2018-08-31 11:31:55', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(419, 'Insert', '2018-08-31 11:35:15', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(420, 'Insert', '2018-08-31 11:39:55', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(421, 'Insert', '2018-08-31 13:27:43', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(422, 'Insert', '2018-08-31 13:28:59', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(423, 'Insert', '2018-08-31 13:30:13', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(424, 'Insert', '2018-08-31 16:15:00', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(425, 'Insert', '2018-08-31 16:21:51', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(426, 'Insert', '2018-08-31 17:57:09', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 08/02/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 07/11/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(427, 'Insert', '2018-08-31 17:59:06', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 08/02/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 07/11/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(428, 'Insert', '2018-09-01 16:11:25', 'Add Other Group', 'Created new data are as follow:\r\nother_groupid : 3\r\ngroup_type : 19\r\nname : Testing\r\nYear : 2019\r\nstart_date : 12/31/2018 12:00:00 AM\r\nend_date : 4/30/2019 12:00:00 AM\r\ncreatedate : 9/1/2018 4:11:22 PM\r\nregion : 14\r\ncreateuser : 1\r\nisactive : True\r\n', 0, 'admin', '::1'),
(429, 'Insert', '2018-09-01 16:12:07', 'Add Sub Other', 'Created new data are as follow:\r\nsub_other_groupid : 17\r\nother_groupid : 3\r\nsub_other_groupname : Yangon\r\ncreate_date : 9/1/2018 4:11:59 PM\r\ncreate_admin : 1\r\nisactive : True\r\n', 0, 'admin', '::1'),
(430, 'Insert', '2018-09-01 16:12:08', 'Add Sub Other', 'Created new data are as follow:\r\nsub_other_groupid : 18\r\nother_groupid : 3\r\nsub_other_groupname : Mandalay\r\ncreate_date : 9/1/2018 4:12:08 PM\r\ncreate_admin : 1\r\nisactive : True\r\n', 0, 'admin', '::1'),
(431, 'Insert', '2018-09-01 16:12:10', 'Add Sub Other', 'Created new data are as follow:\r\nsub_other_groupid : 19\r\nother_groupid : 3\r\nsub_other_groupname : Bago\r\ncreate_date : 9/1/2018 4:12:09 PM\r\ncreate_admin : 1\r\nisactive : True\r\n', 0, 'admin', '::1');
INSERT INTO `tbl_eventlog` (`ID`, `LogType`, `LogDateTime`, `Source`, `LogMessage`, `UserID`, `UserType`, `ipAddress`) VALUES
(432, 'Insert', '2018-09-01 16:17:29', 'Add Player', 'Created new data are as follow:\r\nplayerid : 51\r\nenroll_number : 555\r\nHPDTid : HPDT/000001/2018\r\nplayer_name : test\r\ngender : True\r\naddress : pyay\r\nnrc : 4/63746\r\npassport : WW2jije\r\nafcid : \r\nposition : 6\r\nnationality : 4\r\nprimary_player_category : 8\r\nsecondary_player_category : 7\r\ndateofbirth : 2/5/2008 12:00:00 AM\r\nphoto :  \r\nisactive : True\r\ncreatedate : 9/1/2018 4:17:28 PM\r\ncreateuser : 1\r\n', 0, 'admin', '::1'),
(433, 'Update', '2018-09-01 16:30:44', 'Update Other Group', 'Updated data are as follow:\r\ncreatedate : 9/1/2018 4:11:22 PM >>> 9/1/2018 4:30:41 PM\r\nregion : 14 >>> 22\r\n', 0, 'admin', '::1'),
(434, 'Insert', '2018-09-01 16:31:07', 'Add Sub Other', 'Created new data are as follow:\r\nsub_other_groupid : 20\r\nother_groupid : 3\r\nsub_other_groupname : Yangon\r\ncreate_date : 9/1/2018 4:31:04 PM\r\ncreate_admin : 1\r\nisactive : True\r\n', 0, 'admin', '::1'),
(435, 'Insert', '2018-09-03 09:23:15', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(436, 'Insert', '2018-09-03 09:28:32', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(437, 'Insert', '2018-09-03 09:35:51', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(438, 'Update', '2018-09-03 10:34:08', 'Update Club', 'Updated data are as follow:\r\nisactive : True >>> False\r\n', 0, 'admin', '::1'),
(439, 'Delete', '2018-09-03 10:34:10', 'Delete SubOther', 'Deleted old data are as follow:\r\nsub_other_groupid : 20\r\nother_groupid : 3\r\nsub_other_groupname : Yangon\r\ncreate_date : 9/1/2018 4:31:04 PM\r\ncreate_admin : 1\r\nisactive : True\r\n', 0, 'admin', '::1'),
(440, 'Insert', '2018-09-03 11:18:17', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(441, 'Insert', '2018-09-03 11:20:25', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(442, 'Insert', '2018-09-03 11:22:55', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(443, 'Insert', '2018-09-03 11:25:40', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(444, 'Insert', '2018-09-03 11:31:31', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(445, 'Insert', '2018-09-03 11:46:25', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(446, 'Insert', '2018-09-03 11:50:34', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(447, 'Insert', '2018-09-03 12:08:15', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(448, 'Insert', '2018-09-03 12:10:26', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(449, 'Insert', '2018-09-03 13:09:39', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(450, 'Insert', '2018-09-03 13:19:43', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(451, 'Insert', '2018-09-03 13:20:29', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(452, 'Insert', '2018-09-03 13:34:09', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(453, 'Update', '2018-09-03 15:16:42', 'Update Player Club', 'Updated data are as follow:\r\nend_date : 8/27/2020 12:00:00 AM >>> 12/31/2018 12:00:00 AM\r\n', 0, 'admin', '::1'),
(454, 'Update', '2018-09-03 15:20:40', 'Update Player Club', 'Updated data are as follow:\r\nend_date : 12/31/2019 12:00:00 AM >>> 9/10/2018 12:00:00 AM\r\n', 0, 'admin', '::1'),
(455, 'Insert', '2018-09-04 10:09:05', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(456, 'Insert', '2018-09-04 10:46:34', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(457, 'Insert', '2018-09-04 10:48:22', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(458, 'Insert', '2018-09-04 10:53:12', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(459, 'Insert', '2018-09-04 11:04:33', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(460, 'Insert', '2018-09-04 11:11:25', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(461, 'Insert', '2018-09-04 11:14:50', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(462, 'Insert', '2018-09-04 11:20:44', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(463, 'Insert', '2018-09-04 11:22:54', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(464, 'Insert', '2018-09-04 11:46:45', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(465, 'Insert', '2018-09-04 13:16:07', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(466, 'Insert', '2018-09-04 13:18:37', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(467, 'Update', '2018-09-04 13:24:11', 'Update Admin', 'Updated data are as follow:\r\n', 0, 'admin', '::1'),
(468, 'Update', '2018-09-04 13:27:22', 'Update Admin', 'Updated data are as follow:\r\n', 0, 'admin', '::1'),
(469, 'Delete', '2018-09-04 13:28:45', 'Delete Admin', 'Deleted old data are as follow:\r\nAdminID : 4\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : yanyan\r\ncreated_date : 8/9/2018 2:00:31 PM\r\nEmail : agag@gmail.com\r\nImagePath : 4.jpg\r\nlogin_fail_count : 0\r\nLoginName : popo\r\nmodified_date : 8/9/2018 2:00:31 PM\r\nPassword : SzKrYj+KLRcD/h5xjUtWqTY6z8DsQgik\r\nSalt : MVKLALehouKM6sB0+iJT7gIHKX6F7PiO\r\n', 0, 'admin', '::1'),
(470, 'Update', '2018-09-04 13:35:41', 'Update Admin Level', 'Updated data are as follow:\r\nmodified_date : 8/28/2018 11:10:11 AM >>> 9/4/2018 1:35:40 PM\r\n', 0, 'admin', '::1'),
(471, 'Insert', '2018-09-04 13:47:07', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(472, 'Insert', '2018-09-04 13:50:09', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(473, 'Insert', '2018-09-04 13:57:52', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(474, 'Insert', '2018-09-04 14:00:21', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(475, 'Insert', '2018-09-04 14:02:45', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(476, 'Insert', '2018-09-04 14:06:29', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(477, 'Insert', '2018-09-04 14:11:20', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(478, 'Insert', '2018-09-04 14:12:34', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(479, 'Insert', '2018-09-04 14:34:44', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(480, 'Insert', '2018-09-04 15:06:11', 'Add General', 'Created new data are as follow:\r\nid : 23\r\nname : Burma\r\ntype : Nationality\r\nisactive : True\r\n', 0, 'admin', '::1'),
(481, 'Update', '2018-09-04 15:08:35', 'Update General', 'Updated data are as follow:\r\nname : Football >>> Women Football\r\n', 0, 'admin', '::1'),
(482, 'Delete', '2018-09-04 15:09:35', 'Delete General', 'Deleted old data are as follow:\r\nid : 22\r\nname : MaGwe\r\ntype : State\r\nisactive : False\r\n', 0, 'admin', '::1'),
(483, 'Insert', '2018-09-04 16:05:18', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(484, 'Insert', '2018-09-04 16:23:26', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(485, 'Update', '2018-09-04 16:33:56', 'Update Player', 'Updated data are as follow:\r\nafcid :  >>> 43431\r\ncreatedate : 8/29/2018 4:18:07 PM >>> 9/4/2018 4:33:56 PM\r\n', 0, 'admin', '::1'),
(486, 'Insert', '2018-09-04 16:35:56', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(487, 'Insert', '2018-09-04 16:36:43', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(488, 'Insert', '2018-09-04 16:39:11', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(489, 'Insert', '2018-09-04 16:43:33', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(490, 'Insert', '2018-09-04 16:47:06', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(491, 'Insert', '2018-09-04 16:55:07', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(492, 'Insert', '2018-09-04 17:01:27', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(493, 'Delete', '2018-09-04 17:01:29', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 148\r\nplayerid : 49\r\nattachfilename : 148.xls\r\n', 0, 'admin', '::1'),
(494, 'Insert', '2018-09-04 17:05:19', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(495, 'Insert', '2018-09-04 17:07:55', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(496, 'Insert', '2018-09-04 17:11:41', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(497, 'Insert', '2018-09-05 09:36:20', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(498, 'Delete', '2018-09-05 10:50:36', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 12\r\nplayer_clubid : 13\r\nattachfilename : 12.jpg\r\n', 0, 'admin', '::1'),
(499, 'Update', '2018-09-05 10:59:44', 'Update Player Club', 'Updated data are as follow:\r\njoin_date : 8/27/2018 12:00:00 AM >>> 8/1/2018 12:00:00 AM\r\nend_date : 8/28/2018 12:00:00 AM >>> 9/1/2018 12:00:00 AM\r\ncreatedate : 8/27/2018 11:14:53 AM >>> 9/5/2018 10:59:40 AM\r\n', 0, 'admin', '::1'),
(500, 'Insert', '2018-09-05 11:05:40', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(501, 'Insert', '2018-09-05 11:07:07', 'Add Player', 'Created new data are as follow:\r\nplayerid : 50\r\nenroll_number : 8901\r\nHPDTid : HPDT/000004/2018\r\nplayer_name : test\r\ngender : False\r\naddress : Mandalay\r\nnrc : 14/62362\r\npassport : \r\nafcid : \r\nposition : 6\r\nnationality : 23\r\nprimary_player_category : 10\r\nsecondary_player_category : 9\r\ndateofbirth : 8/4/2002 12:00:00 AM\r\nphoto :  \r\nisactive : True\r\ncreatedate : 9/5/2018 11:07:00 AM\r\ncreateuser : 1\r\n', 0, 'admin', '::1'),
(502, 'Insert', '2018-09-05 11:08:42', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(503, 'Insert', '2018-09-05 11:16:56', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(504, 'Insert', '2018-09-05 11:21:58', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(505, 'Insert', '2018-09-05 11:25:50', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(506, 'Insert', '2018-09-05 11:31:01', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(507, 'Insert', '2018-09-05 11:39:17', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(508, 'Insert', '2018-09-05 11:49:01', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(509, 'Insert', '2018-09-05 11:54:30', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(510, 'Insert', '2018-09-05 11:56:28', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(511, 'Insert', '2018-09-05 12:58:04', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(512, 'Insert', '2018-09-05 13:00:53', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(513, 'Insert', '2018-09-05 13:07:58', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(514, 'Insert', '2018-09-05 13:16:48', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(515, 'Insert', '2018-09-05 13:30:46', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(516, 'Insert', '2018-09-05 13:47:21', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(517, 'Insert', '2018-09-05 13:49:12', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(518, 'Insert', '2018-09-05 13:59:41', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(519, 'Update', '2018-09-05 14:04:05', 'Update Club', 'Updated data are as follow:\r\nteam_manager : U Hla >>> U ko ko\r\n', 0, 'admin', '::1'),
(520, 'Insert', '2018-09-05 14:04:31', 'Add Sub Club', 'Created new data are as follow:\r\nsub_clubid : 33\r\nclubid : 23\r\nsub_clubname : MG1\r\nisactive : True\r\ncreate_date : 9/5/2018 2:04:27 PM\r\ncreate_admin : 1\r\n', 0, 'admin', '::1'),
(521, 'Insert', '2018-09-05 14:04:39', 'Add Sub Club', 'Created new data are as follow:\r\nsub_clubid : 34\r\nclubid : 23\r\nsub_clubname : MG2\r\nisactive : True\r\ncreate_date : 9/5/2018 2:04:36 PM\r\ncreate_admin : 1\r\n', 0, 'admin', '::1'),
(522, 'Update', '2018-09-05 14:10:18', 'Update Club', 'Updated data are as follow:\r\nisactive : True >>> False\r\n', 0, 'admin', '::1'),
(523, 'Insert', '2018-09-05 14:48:11', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(524, 'Insert', '2018-09-05 14:48:57', 'Add Club', 'Created new data are as follow:\r\nclubid : 24\r\nclubname : SSW\r\nteam_manager : U Htet\r\nphone : 09987662\r\nemail : htet@gmail.com\r\naddress : Nay Pyi Taw\r\nlogo : \r\nisactive : True\r\ncreatedate : 9/5/2018 2:48:54 PM\r\ncreateuser : 1\r\n', 0, 'admin', '::1'),
(525, 'Insert', '2018-09-05 14:49:49', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(526, 'Insert', '2018-09-05 14:59:26', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(527, 'Update', '2018-09-05 14:59:29', 'Update Club', 'Updated data are as follow:\r\n', 0, 'admin', '::1'),
(528, 'Insert', '2018-09-05 14:59:33', 'Add Sub Club', 'Created new data are as follow:\r\nsub_clubid : 37\r\nclubid : 24\r\nsub_clubname : SS1\r\nisactive : True\r\ncreate_date : 9/5/2018 2:59:32 PM\r\ncreate_admin : 1\r\n', 0, 'admin', '::1'),
(529, 'Update', '2018-09-05 15:02:32', 'Update Club', 'Updated data are as follow:\r\n', 0, 'admin', '::1'),
(530, 'Insert', '2018-09-05 15:02:35', 'Add Sub Club', 'Created new data are as follow:\r\nsub_clubid : 38\r\nclubid : 24\r\nsub_clubname : SS1\r\nisactive : True\r\ncreate_date : 9/5/2018 3:02:34 PM\r\ncreate_admin : 1\r\n', 0, 'admin', '::1'),
(531, 'Insert', '2018-09-05 15:02:58', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(532, 'Insert', '2018-09-05 15:08:47', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(533, 'Insert', '2018-09-05 15:11:24', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(534, 'Insert', '2018-09-05 15:24:18', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(535, 'Insert', '2018-09-05 15:28:06', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(536, 'Delete', '2018-09-05 15:29:18', 'Delete Attachment', 'Deleted old data are as follow:\r\nattachid : 11\r\nclubid : 24\r\nattachfilename : 11.png\r\n', 0, 'admin', '::1'),
(537, 'Insert', '2018-09-05 15:55:07', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(538, 'Insert', '2018-09-05 16:06:27', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(539, 'Insert', '2018-09-05 16:06:34', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(540, 'Insert', '2018-09-05 16:08:42', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(541, 'Insert', '2018-09-05 16:28:50', 'Add Player Club', 'Created new data are as follow:\r\nplayer_clubid : 16\r\nplayerid : 43\r\nsub_clubid : 10\r\nclubid : 24\r\njoin_date : 9/5/2018 12:00:00 AM\r\nend_date : 10/31/2018 12:00:00 AM\r\ncreatedate : 9/5/2018 4:28:32 PM\r\ncreateuser : 1\r\nisactive : True\r\n', 0, 'admin', '::1'),
(542, 'Update', '2018-09-05 16:30:01', 'Update Player Club', 'Updated data are as follow:\r\nend_date : 3/31/2021 12:00:00 AM >>> 9/30/2018 12:00:00 AM\r\n', 0, 'admin', '::1'),
(543, 'Insert', '2018-09-05 16:40:54', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(544, 'Insert', '2018-09-05 16:47:25', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(545, 'Insert', '2018-09-05 16:47:37', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(546, 'Insert', '2018-09-05 16:54:37', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(547, 'Insert', '2018-09-05 17:01:28', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(548, 'Insert', '2018-09-05 17:05:11', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(549, 'Insert', '2018-09-05 17:05:53', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(550, 'Insert', '2018-09-05 17:09:24', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(551, 'Insert', '2018-09-05 17:12:47', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(552, 'Insert', '2018-09-05 17:16:51', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(553, 'Insert', '2018-09-05 17:20:12', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(554, 'Insert', '2018-09-05 17:37:04', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(555, 'Insert', '2018-09-06 09:33:38', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1');
INSERT INTO `tbl_eventlog` (`ID`, `LogType`, `LogDateTime`, `Source`, `LogMessage`, `UserID`, `UserType`, `ipAddress`) VALUES
(556, 'Insert', '2018-09-06 09:36:52', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(557, 'Insert', '2018-09-06 09:40:26', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(558, 'Insert', '2018-09-06 09:44:47', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(559, 'Insert', '2018-09-06 09:48:01', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(560, 'Insert', '2018-09-06 09:49:14', 'Add FingetTemplate', 'Created new data are as follow:\r\ntemplateid : 17\r\nplayerid : 49\r\nfingerid : 3\r\nfingertemplate : System.Byte[]\r\nmodified_date : 9/6/2018 9:49:06 AM\r\n', 0, 'admin', '172.31.131.4'),
(561, 'Insert', '2018-09-06 09:50:46', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(562, 'Insert', '2018-09-06 09:51:42', 'Add FingetTemplate', 'Created new data are as follow:\r\ntemplateid : 18\r\nplayerid : 49\r\nfingerid : 5\r\nfingertemplate : System.Byte[]\r\nmodified_date : 9/6/2018 9:51:42 AM\r\n', 0, 'admin', '172.31.131.4'),
(563, 'Insert', '2018-09-06 09:53:33', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(564, 'Insert', '2018-09-06 09:54:54', 'Add FingetTemplate', 'Created new data are as follow:\r\ntemplateid : 19\r\nplayerid : 49\r\nfingerid : 7\r\nfingertemplate : System.Byte[]\r\nmodified_date : 9/6/2018 9:54:53 AM\r\n', 0, 'admin', '172.31.131.4'),
(565, 'Insert', '2018-09-06 09:58:22', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(566, 'Insert', '2018-09-06 10:00:10', 'Add FingetTemplate', 'Created new data are as follow:\r\ntemplateid : 20\r\nplayerid : 49\r\nfingerid : 0\r\nfingertemplate : System.Byte[]\r\nmodified_date : 9/6/2018 10:00:08 AM\r\n', 0, 'admin', '172.31.131.4'),
(567, 'Insert', '2018-09-06 10:02:10', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(568, 'Insert', '2018-09-06 10:03:19', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(569, 'Insert', '2018-09-06 10:05:29', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(570, 'Insert', '2018-09-06 10:10:35', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(571, 'Insert', '2018-09-06 10:13:25', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(572, 'Insert', '2018-09-06 10:18:12', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1'),
(573, 'Insert', '2018-09-06 10:21:59', 'Admin Login', 'Created new data are as follow:\r\nAdminID : 1\r\naccess_status : 0\r\nAdminLevelID : 1\r\nAdminName : Admin\r\ncreated_date : 2/8/2018 4:22:25 PM\r\nEmail : thandalay@gmail.com\r\nImagePath : 1.jpg\r\nlogin_fail_count : 0\r\nLoginName : admin\r\nmodified_date : 11/7/2017 10:08:35 AM\r\nPassword : wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt\r\nSalt : /SApKtKXpIa6YnHCjKLxQJAeb279BlX8\r\n', 1, 'admin', '127.0.0.1');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_fingertemplatezk`
--

CREATE TABLE `tbl_fingertemplatezk` (
  `templateid` int(11) NOT NULL,
  `playerid` int(11) DEFAULT NULL,
  `fingerid` int(11) DEFAULT NULL,
  `fingertemplate` longblob,
  `modified_date` timestamp NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `tbl_fingertemplatezk`
--

INSERT INTO `tbl_fingertemplatezk` (`templateid`, `playerid`, `fingerid`, `fingertemplate`, `modified_date`) VALUES
(2, 50, 2, NULL, '2018-08-29 17:30:00'),
(3, 47, 1, NULL, '2018-08-29 17:30:00'),
(4, 47, 2, NULL, '2018-08-29 17:30:00'),
(14, 48, 1, 0x1c61440c2040, '2018-08-30 08:46:15'),
(15, 48, 2, 0x6466646664667364, '2018-08-31 03:12:02'),
(16, 48, 3, 0x667364736461, '2018-08-31 03:12:24');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_general`
--

CREATE TABLE `tbl_general` (
  `id` bigint(20) NOT NULL,
  `name` varchar(500) COLLATE utf8_unicode_ci NOT NULL,
  `type` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `isactive` tinyint(1) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci ROW_FORMAT=COMPACT;

--
-- Dumping data for table `tbl_general`
--

INSERT INTO `tbl_general` (`id`, `name`, `type`, `isactive`) VALUES
(1, 'Yangon', 'State', 1),
(2, 'Tarmwe', 'Township', 1),
(3, 'Goalkeeper ', 'Position', 1),
(4, 'Kayin', 'Nationality', 1),
(5, 'Defenders', 'Position', 1),
(6, 'Midfielders', 'Position', 1),
(7, 'Men Fusel', 'Player Category', 1),
(8, 'Men FootBall', 'Player Category', 1),
(9, 'Women Fusel', 'Player Category', 1),
(10, 'Women Football', 'Player Category', 1),
(11, 'Hlegu', 'Township', 1),
(12, 'Shan', 'Nationality', 1),
(13, 'Bago', 'State', 0),
(14, 'Mandalay', 'State', 1),
(15, 'Pyay', 'State', 0),
(16, 'InSein', 'Township', 1),
(17, 'Bago', 'State', 0),
(18, 'Bago', 'State', 1),
(19, 'Tournament', 'Other Group Type', 1),
(20, 'Academy', 'Other Group Type', 1),
(21, 'KaChin', 'State', 0),
(22, 'MaGwe', 'State', 0),
(23, 'Burma', 'Nationality', 1);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_other_group`
--

CREATE TABLE `tbl_other_group` (
  `other_groupid` bigint(20) NOT NULL,
  `group_type` bigint(20) NOT NULL,
  `name` varchar(255) NOT NULL,
  `Year` int(11) NOT NULL,
  `start_date` datetime NOT NULL,
  `end_date` datetime NOT NULL,
  `region` bigint(20) NOT NULL,
  `createdate` datetime NOT NULL,
  `createuser` bigint(20) NOT NULL,
  `isactive` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_other_group`
--

INSERT INTO `tbl_other_group` (`other_groupid`, `group_type`, `name`, `Year`, `start_date`, `end_date`, `region`, `createdate`, `createuser`, `isactive`) VALUES
(1, 19, 'Regional', 2018, '2018-09-01 00:00:00', '2018-12-01 00:00:00', 1, '2018-09-01 00:00:00', 1, 1),
(2, 20, 'DIvisional', 2018, '2018-09-01 00:00:00', '2018-12-31 00:00:00', 14, '2018-09-01 00:00:00', 1, 1),
(3, 19, 'Testing', 2019, '2018-12-31 00:00:00', '2019-04-30 00:00:00', 22, '2018-09-01 16:30:41', 1, 0);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_player`
--

CREATE TABLE `tbl_player` (
  `playerid` bigint(20) NOT NULL,
  `enroll_number` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,
  `HPDTid` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,
  `player_name` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `gender` tinyint(4) NOT NULL,
  `address` text COLLATE utf8_unicode_ci NOT NULL,
  `nrc` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `passport` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,
  `afcid` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,
  `position` bigint(20) NOT NULL,
  `nationality` bigint(20) NOT NULL,
  `primary_player_category` bigint(20) NOT NULL,
  `secondary_player_category` bigint(20) NOT NULL,
  `dateofbirth` datetime NOT NULL,
  `photo` text COLLATE utf8_unicode_ci,
  `isactive` tinyint(4) NOT NULL,
  `createdate` datetime NOT NULL,
  `createuser` bigint(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `tbl_player`
--

INSERT INTO `tbl_player` (`playerid`, `enroll_number`, `HPDTid`, `player_name`, `gender`, `address`, `nrc`, `passport`, `afcid`, `position`, `nationality`, `primary_player_category`, `secondary_player_category`, `dateofbirth`, `photo`, `isactive`, `createdate`, `createuser`) VALUES
(1, '001', '', 'Mg Mg', 1, 'Yangon', '11238738', '2434788', '123', 3, 4, 1, 1, '2010-07-14 00:00:00', '', 1, '0000-00-00 00:00:00', 0),
(4, '002', '', 'Kyaw Kyaw', 1, 'Yangon', '1234556', '1234', 'hh', 3, 4, 7, 8, '1996-02-13 00:00:00', '', 0, '2018-07-30 17:01:59', 1),
(5, '0007', '', 'aung aung', 1, 'y', '54546567', '666668', '300', 3, 4, 8, 8, '2000-02-05 00:00:00', ' ', 1, '2018-08-03 11:53:02', 1),
(6, '00055', '', 'Aye Aye', 0, 'Yangon', '454545', '34343', '3330', 3, 12, 9, 9, '1998-09-08 00:00:00', ' ', 0, '2018-08-03 12:00:11', 1),
(7, '005', '', 'mya mya', 0, 'mandalay', '45456', '34356', '3434', 3, 4, 9, 9, '1998-05-21 00:00:00', ' ', 1, '2018-08-03 13:45:37', 1),
(8, '0057', '', 'gg', 1, 'pyY', '343535', '3434', '3434', 3, 4, 7, 7, '2009-09-07 00:00:00', ' ', 1, '2018-08-03 17:15:02', 1),
(9, '989', '', 'jyjgj', 0, 'fhhf', '7878', '7i97', '7yi', 3, 4, 7, 7, '2012-01-16 00:00:00', ' ', 0, '2018-08-03 17:26:17', 1),
(10, '00095', '', 'kyu kyu', 0, '556', '5656', '656564', '4535', 3, 4, 10, 10, '2010-08-11 00:00:00', '10.PNG', 1, '2018-08-04 10:26:38', 1),
(11, '5678', '', 'Htet Htet', 0, 'mandalay', '43535', '454545', '3344', 5, 4, 10, 10, '2001-01-30 00:00:00', 'Wanna-One91.jpg', 1, '2018-08-07 12:44:56', 1),
(12, '5556', '', 'Ei Ei', 0, 'Yangon ', '454546', 't5455', '5656', 3, 4, 8, 8, '1998-12-09 00:00:00', 'th.jpg', 1, '2018-08-07 11:34:10', 1),
(13, '808', '', 'koko', 1, 'Pyay', '3434tt', '3434555', '12', 5, 4, 7, 7, '2000-03-06 00:00:00', ' ', 0, '2018-08-06 11:23:03', 1),
(19, '00986', '', 'Thiha', 1, 'ygn', '0972469', '00987654', '8889', 3, 4, 8, 8, '1998-05-13 00:00:00', ' ', 1, '2018-08-07 14:06:20', 1),
(20, '00786', '', 'Zaw Zaw', 1, 'Yangon', '7778899', '34344567', '233', 5, 4, 8, 8, '2001-12-02 00:00:00', ' ', 0, '2018-08-07 14:24:08', 1),
(21, '50030', '', 'Ye Ko', 1, 'Bago', '888854', '109832', '1002', 3, 4, 8, 8, '2001-08-27 00:00:00', ' ', 0, '2018-08-07 14:34:51', 1),
(22, '4000', '', 'Thi Thi', 0, 'Pyay', '012345', '000111', '3455', 3, 4, 10, 10, '1998-09-08 00:00:00', ' ', 1, '2018-08-07 14:43:22', 1),
(23, '8080', '', 'Htet Lin', 1, 'Mandalay', '111123', '222233', '0098', 3, 4, 10, 10, '2004-01-13 00:00:00', '23.jpg', 1, '2018-08-07 16:29:53', 1),
(24, '57689', '', 'Thet Aung', 0, 'Mandalay', '188432', '0987553', '0034', 3, 4, 7, 10, '2000-04-11 00:00:00', '24.jpg', 1, '2018-08-09 14:11:31', 1),
(25, '40089', '', 'oo', 1, '127,aa street,Yangon', '4/938439', '1298773', '099877', 3, 4, 7, 8, '1997-03-11 00:00:00', '25.jpg', 1, '2018-08-21 15:30:36', 1),
(26, '093747', '', 'Htetbll', 1, 'yangon', '188000', 'qwqw', '455', 3, 12, 7, 10, '2008-02-13 00:00:00', '26.jpg', 0, '2018-08-09 14:56:02', 1),
(27, '30002', '', 'Mg Mg', 1, 'Yangon', '2/37483', '1.MMjwiei', '0982', 5, 12, 8, 10, '2001-12-04 00:00:00', '27.jpg', 1, '2018-08-17 10:02:03', 1),
(28, '55000', '', 'Aung Kyaw', 1, 'Bago', '2/823983', '128h8883', '8976', 3, 12, 7, 10, '2001-01-28 00:00:00', '28.jpg', 0, '2018-08-10 17:28:49', 1),
(29, '40099', '', 'Aung Thu', 1, 'ygn', '34545', '23234', '434', 3, 4, 7, 8, '2000-06-25 00:00:00', '29.jpg', 1, '2018-08-16 13:57:25', 1),
(30, '55555', '', 'gr', 0, '4gg', '455', '3434565', 'wew', 3, 4, 7, 7, '2002-04-02 00:00:00', ' ', 0, '2018-08-10 17:43:14', 1),
(31, '80010', '', 'Kyaw Thura', 1, 'Taung Gyi', '12/TT6374', '103844', '8756', 3, 12, 8, 7, '2000-03-01 00:00:00', '31.jpg', 1, '2018-08-17 09:56:06', 1),
(32, '20001', '', 'Mg Aung', 1, 'Shan', '12/LL2839', '2536266', '93477', 5, 12, 8, 7, '2001-10-01 00:00:00', '32.jpg', 1, '2018-08-11 13:46:32', 1),
(33, '20000', '', 'AA', 1, 'AAA', '12', '12', 'AA', 3, 4, 7, 8, '2018-08-01 00:00:00', '33.jpg', 0, '2018-08-15 10:42:59', 1),
(34, '478748', '', 'htoohtoo', 1, 'yangon', '433rtrt', '4545gttt', '4', 3, 12, 7, 8, '2000-01-04 00:00:00', '34.jpg', 0, '2018-08-16 12:03:22', 1),
(35, '', '', 'tt', 0, 'tt', '45455532', 'rt4545', '', 3, 4, 9, 10, '2001-08-29 00:00:00', '35.png', 0, '2018-08-16 14:55:52', 1),
(36, '000006', '', 'yyt', 0, 'ertyu', 'uiui', '', '', 3, 12, 8, 7, '2010-08-03 00:00:00', '36.jpg', 0, '2018-08-16 15:35:11', 1),
(37, '100002', '', 'werrt', 1, 'red', '343423eed', 'dfer34', '', 5, 4, 10, 9, '2006-06-01 00:00:00', ' ', 0, '2018-08-16 15:40:08', 1),
(38, '88990', '', 'ttr', 0, 'tty', '5tty77', '45656', '', 6, 4, 8, 7, '2018-08-05 00:00:00', '38.jpg', 0, '2018-08-16 15:44:07', 1),
(39, '86', '', 'rere', 0, 'wertyui', '7y7y7', '87rf8', '', 3, 12, 9, 10, '2017-02-20 00:00:00', '39.jpg', 0, '2018-08-16 15:55:25', 1),
(40, '456789', '', 'wertyuio', 1, 'fjkl', 'sdfghjk', '3456789k', '', 5, 4, 8, 7, '2011-03-01 00:00:00', '40.jpg', 0, '2018-08-16 16:05:49', 1),
(41, '5678909', '', 'yyuii', 1, 'dfghjk', '56789', 'uu6800', '', 3, 4, 10, 7, '2004-05-02 00:00:00', '41.jpg', 0, '2018-08-16 16:10:51', 1),
(42, '67890p', '', 'asa', 1, 'fhkl', 'olk', '7889yy', '', 3, 12, 9, 8, '2018-08-16 00:00:00', '42.jpg', 0, '2018-08-16 16:15:06', 1),
(43, '567890', '', 'wwt', 1, 'ygn', '6789', '0987654', '', 3, 4, 8, 8, '2018-08-16 00:00:00', '43.jpg', 1, '2018-08-16 16:20:12', 1),
(44, '7500', '', 'Joker', 1, 'ygn', '678jdji3', '8984054', '', 3, 12, 8, 7, '2008-04-09 00:00:00', '44.jpg', 1, '2018-08-16 16:44:23', 1),
(45, '79000', '', 'Lin Lin', 1, 'yangon', '7732783', '', '', 3, 12, 7, 10, '2004-04-28 00:00:00', '45.jpg', 1, '2018-08-17 09:27:29', 1),
(46, '8765', '', 'Lucy', 0, 'Yangon', '12/e887654', '882', '800', 3, 12, 9, 10, '1998-02-02 00:00:00', '46.jpg', 1, '2018-08-20 10:35:43', 1),
(47, '77', 'HPDT/000002/2018', 'Joone', 1, 'hh', '3/4546', '42222', '44', 3, 4, 7, 8, '2010-12-21 00:00:00', '47.png', 1, '2018-08-20 10:37:45', 1),
(48, '03898', 'HPDT/000001/2018', 'Jin', 1, 'ygn', '3434jfsda', '454657y', '37847h', 3, 12, 8, 7, '2001-05-06 00:00:00', '48.png', 1, '2018-08-23 12:59:44', 1),
(49, '43431', 'HPDT/000003/2018', 'htoo', 1, 'ygn', '12/er738', 'err343er43', '43431', 5, 4, 10, 7, '2005-10-25 00:00:00', '49.jpg', 1, '2018-09-04 16:33:56', 1),
(50, '8901', 'HPDT/000004/2018', 'test', 0, 'Mandalay', '14/62362', '', '', 6, 23, 10, 9, '2002-08-04 00:00:00', '50.jpg', 1, '2018-09-05 11:07:00', 1);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_player_attachment`
--

CREATE TABLE `tbl_player_attachment` (
  `attachid` bigint(20) NOT NULL,
  `playerid` bigint(20) NOT NULL,
  `attachfilename` text COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `tbl_player_attachment`
--

INSERT INTO `tbl_player_attachment` (`attachid`, `playerid`, `attachfilename`) VALUES
(1, 4, '1.jpg'),
(2, 10, '2.jpg'),
(3, 11, '3.jpg'),
(4, 12, '4.xls'),
(9, 13, '1.Design Engineering.pdf'),
(10, 13, '2.Architectural design.pdf'),
(13, 24, '24.jpg'),
(17, 26, '26.jpg'),
(21, 27, '27.pptx'),
(22, 27, '27.jpg'),
(23, 25, '25.pdf'),
(24, 28, '28.jpg'),
(25, 28, '28.xls'),
(26, 29, '29.jpg'),
(27, 29, '29.xls'),
(29, 25, '25.jpg'),
(30, 31, '31.jpg'),
(33, 31, '31.pdf'),
(34, 27, '27.pdf'),
(35, 34, '34.jpg'),
(36, 34, '34.xls'),
(37, 35, '37.png'),
(38, 35, '38.xls'),
(39, 36, '39.jpg'),
(40, 36, '40.xls'),
(41, 38, '41.png'),
(42, 38, '42.xls'),
(43, 39, '43.jpg'),
(44, 39, '44.xls'),
(45, 40, '45.jpg'),
(46, 40, '46.xls'),
(47, 41, '47.jpg'),
(48, 41, '48.xls'),
(49, 42, '49.png'),
(50, 42, '50.xls'),
(52, 43, '52.xls'),
(55, 44, '55.xls'),
(69, 25, '69.txt'),
(74, 46, '74.png'),
(75, 46, '75.txt'),
(77, 48, '77.jpg'),
(110, 45, '110.txt'),
(111, 45, '111.txt'),
(112, 45, '112.txt'),
(113, 45, '113.txt'),
(114, 45, '114.txt'),
(131, 48, '131.jpg'),
(132, 48, '132.txt'),
(140, 48, '140.PNG'),
(141, 48, '141.jpg'),
(142, 48, '142.PNG'),
(143, 47, '143.jpg'),
(144, 46, '144.PNG'),
(145, 46, '145.txt'),
(146, 50, '146.jpg'),
(147, 49, '147.jpg'),
(149, 49, '149.pdf');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_player_category_history`
--

CREATE TABLE `tbl_player_category_history` (
  `historyid` bigint(20) NOT NULL,
  `playerid` bigint(20) NOT NULL,
  `primary_player_category` bigint(20) NOT NULL,
  `secondary_player_category` bigint(20) NOT NULL,
  `changedate` datetime NOT NULL,
  `changeuser` bigint(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `tbl_player_category_history`
--

INSERT INTO `tbl_player_category_history` (`historyid`, `playerid`, `primary_player_category`, `secondary_player_category`, `changedate`, `changeuser`) VALUES
(1, 11, 7, 7, '2018-08-07 12:44:53', 1),
(2, 23, 7, 7, '2018-08-07 16:29:51', 1),
(3, 24, 9, 10, '2018-08-07 17:01:46', 1),
(4, 26, 10, 7, '2018-08-09 14:18:50', 1),
(5, 29, 10, 7, '2018-08-16 13:57:15', 1),
(6, 27, 10, 7, '2018-08-17 10:01:53', 1);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_player_club`
--

CREATE TABLE `tbl_player_club` (
  `player_clubid` bigint(20) NOT NULL,
  `playerid` bigint(20) NOT NULL,
  `sub_clubid` bigint(20) NOT NULL,
  `clubid` bigint(20) NOT NULL,
  `join_date` datetime NOT NULL,
  `end_date` datetime NOT NULL,
  `createdate` datetime NOT NULL,
  `createuser` bigint(20) NOT NULL,
  `isactive` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `tbl_player_club`
--

INSERT INTO `tbl_player_club` (`player_clubid`, `playerid`, `sub_clubid`, `clubid`, `join_date`, `end_date`, `createdate`, `createuser`, `isactive`) VALUES
(1, 10, 1, 1, '2017-01-01 00:00:00', '2019-01-01 00:00:00', '2018-08-07 00:00:00', 1, 1),
(2, 11, 2, 2, '2018-06-01 00:00:00', '2019-04-04 00:00:00', '2018-08-07 00:00:00', 1, 1),
(3, 25, 1, 2, '2020-03-22 00:00:00', '2025-01-29 00:00:00', '2018-08-23 13:39:10', 1, 1),
(4, 32, 2, 1, '2019-04-02 00:00:00', '2022-01-25 00:00:00', '2018-08-16 13:30:45', 1, 1),
(6, 25, 20, 11, '2018-08-21 00:00:00', '2022-01-23 00:00:00', '2018-08-20 14:53:29', 1, 1),
(9, 48, 10, 9, '2018-08-23 00:00:00', '2018-08-27 00:00:00', '2018-08-23 00:00:00', 1, 1),
(10, 46, 10, 9, '2018-08-31 00:00:00', '2018-08-24 00:00:00', '2018-08-23 00:00:00', 1, 1),
(11, 44, 11, 9, '2018-11-30 00:00:00', '2018-08-27 00:00:00', '2018-08-23 00:00:00', 1, 1),
(12, 45, 11, 9, '2019-09-27 00:00:00', '2018-09-30 00:00:00', '2018-08-23 00:00:00', 1, 1),
(13, 47, 10, 9, '2018-08-01 00:00:00', '2018-09-01 00:00:00', '2018-09-05 10:59:40', 1, 1),
(14, 45, 10, 9, '2018-08-27 00:00:00', '2018-08-27 00:00:00', '2018-08-27 11:25:50', 1, 1),
(15, 43, 10, 9, '2018-08-27 00:00:00', '2018-09-05 00:00:00', '2018-08-27 11:30:01', 1, 1),
(16, 43, 10, 24, '2018-09-05 00:00:00', '2018-10-31 00:00:00', '2018-09-05 16:28:32', 1, 1);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_player_club_attachment`
--

CREATE TABLE `tbl_player_club_attachment` (
  `attachid` bigint(20) NOT NULL,
  `player_clubid` bigint(20) NOT NULL,
  `attachfilename` text COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `tbl_player_club_attachment`
--

INSERT INTO `tbl_player_club_attachment` (`attachid`, `player_clubid`, `attachfilename`) VALUES
(5, 6, '5.xls'),
(6, 5, '6.png'),
(8, 3, '8.pdf'),
(9, 0, '9.png'),
(10, 0, '10.png'),
(11, 15, '11.png'),
(13, 13, '13.jpg'),
(14, 12, '14.xls');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_player_history`
--

CREATE TABLE `tbl_player_history` (
  `historyid` bigint(20) NOT NULL,
  `playerid` bigint(20) NOT NULL,
  `enroll_number` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,
  `HPDTid` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,
  `player_name` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `gender` tinyint(4) NOT NULL,
  `address` text COLLATE utf8_unicode_ci NOT NULL,
  `nrc` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `passport` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,
  `afcid` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `position` bigint(20) NOT NULL,
  `nationality` bigint(20) NOT NULL,
  `primary_player_category` bigint(20) NOT NULL,
  `secondary_player_category` bigint(20) NOT NULL,
  `dateofbirth` datetime NOT NULL,
  `photo` text COLLATE utf8_unicode_ci,
  `isactive` tinyint(4) NOT NULL,
  `changedate` datetime NOT NULL,
  `changeuser` bigint(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `tbl_player_history`
--

INSERT INTO `tbl_player_history` (`historyid`, `playerid`, `enroll_number`, `HPDTid`, `player_name`, `gender`, `address`, `nrc`, `passport`, `afcid`, `position`, `nationality`, `primary_player_category`, `secondary_player_category`, `dateofbirth`, `photo`, `isactive`, `changedate`, `changeuser`) VALUES
(1, 0, '5556', '5656', 'yuyu', 0, 'ygn', '4545', 't5455', '5656', 3, 4, 8, 8, '1998-12-09 00:00:00', 'th.jpg', 1, '2018-08-07 11:34:06', 1),
(2, 11, '5678', '2334', 'juju', 0, 'mandalay', '43535', '454545', '3344', 5, 4, 7, 7, '2001-01-30 00:00:00', 'Wanna-One91.jpg', 1, '2018-08-07 12:02:53', 1),
(3, 11, '5678', '2334', 'juju', 0, 'mandalay', '43535', '454545', '3344', 5, 4, 7, 7, '2001-01-30 00:00:00', 'Wanna-One91.jpg', 1, '2018-08-07 12:06:39', 1),
(4, 11, '5678', '2334', 'juju', 0, 'mandalay', '43535', '454545', '3344', 5, 4, 7, 7, '2001-01-30 00:00:00', 'Wanna-One91.jpg', 1, '2018-08-07 12:44:52', 1),
(5, 23, '8080', 'HPDT8765', 'Htet Lin', 1, 'Yangon', '111123', '222233', '0098', 3, 4, 7, 7, '2004-01-13 00:00:00', '23.jpg', 1, '2018-08-07 16:29:49', 1),
(6, 24, '57689', 'HPDT01', 'Thet Thet', 0, 'Yangon', '188432', '0987553', '0034', 3, 4, 9, 10, '2000-04-11 00:00:00', '24.jpg', 1, '2018-08-07 17:01:46', 1),
(7, 24, '57689', 'HPDT01', 'Thet Thet', 0, 'Mandalay', '188432', '0987553', '0034', 3, 4, 7, 10, '2000-04-11 00:00:00', '24.jpg', 1, '2018-08-09 14:11:28', 1),
(8, 26, '093747', 'HPDT44', 'Htet', 1, 'yangon', '188000', 'qwqw', '455', 3, 4, 10, 7, '2008-02-13 00:00:00', '26.jpg', 1, '2018-08-09 14:18:49', 1),
(9, 26, '093747', 'HPDT44', 'Htet', 1, 'yangon', '188000', 'qwqw', '455', 3, 12, 7, 10, '2008-02-13 00:00:00', '26.jpg', 1, '2018-08-09 14:39:25', 1),
(10, 26, '093747', 'HPDT44', 'Htetaa', 1, 'yangon', '188000', 'qwqw', '455', 3, 12, 7, 10, '2008-02-13 00:00:00', '26.jpg', 1, '2018-08-09 14:40:40', 1),
(11, 26, '093747', 'HPDT44', 'Htetbb', 1, 'yangon', '188000', 'qwqw', '455', 3, 12, 7, 10, '2008-02-13 00:00:00', '26.jpg', 1, '2018-08-09 14:45:04', 1),
(12, 26, '093747', 'HPDT44', 'Htetbbmmmm', 1, 'yangon', '188000', 'qwqw', '455', 3, 12, 7, 10, '2008-02-13 00:00:00', '26.jpg', 1, '2018-08-09 14:56:00', 1),
(13, 25, '40089', 'HPDT5678', 'Kg Sat', 1, 'Mon', '4/938439', '1298773', '099877', 3, 4, 7, 8, '1997-03-11 00:00:00', '25.jpg', 1, '2018-08-09 14:58:53', 1),
(14, 25, '40089', 'HPDT5678', 'Kg Sattttt', 1, 'Mon', '4/938439', '1298773', '099877', 3, 4, 7, 8, '1997-03-11 00:00:00', '25.jpg', 1, '2018-08-09 14:59:55', 1),
(15, 34, '478748', 'nnnt44', 'htoohtoo', 1, 'yangon', '433rtrt', '4545gttt', '4', 3, 12, 7, 8, '2000-01-04 00:00:00', '34.jpg', 1, '2018-08-16 13:41:49', 1),
(16, 32, '20001', 'HPDT3422', 'Mg Aung', 1, 'Shan', '12/LL2839', '2536266', '93477', 5, 12, 8, 7, '2001-10-01 00:00:00', '32.jpg', 1, '2018-08-16 13:44:36', 1),
(17, 34, '478748', 'nnnt44', 'htoohtoo', 1, 'yangon', '433rtrt', '4545gttt', '4', 3, 12, 7, 8, '2000-01-04 00:00:00', '34.jpg', 1, '2018-08-16 13:48:16', 1),
(18, 29, '40099', 'sfffg', 'Aung Aung', 1, 'ygn', '34545', '23234', '434', 3, 12, 10, 7, '2000-06-25 00:00:00', '29.jpg', 1, '2018-08-16 13:56:46', 1),
(19, 31, '80010', 'HPDT0002', 'Kyaw Thura', 1, 'Taung Gyi', '12/TT6374', '103844', '8756', 3, 12, 10, 7, '2000-03-01 00:00:00', '31.jpg', 1, '2018-08-17 09:56:05', 1),
(20, 27, '30002', 'HPDT456', 'Mg Mg', 1, 'Yangon', '2/37483', '1.MMjwiei', '0982', 5, 4, 10, 7, '2001-12-04 00:00:00', '27.jpg', 1, '2018-08-17 10:01:42', 1),
(21, 25, '40089', 'HPDT5678', 'Kg Sat', 1, 'Mon', '4/938439', '1298773', '099877', 3, 4, 7, 8, '1997-03-11 00:00:00', '25.jpg', 1, '2018-08-21 15:30:35', 1),
(22, 48, '03898', '', 'Jin', 1, 'ygn', '3434jfsda', '454657y', '', 3, 12, 8, 7, '2001-05-06 00:00:00', '48.png', 1, '2018-08-23 12:59:43', 1),
(23, 49, '43431', 'HPDT/000003/2018', 'htoo', 1, 'ygn', '12/er738', 'err343er43', '', 5, 4, 10, 7, '2005-10-25 00:00:00', ' ', 1, '2018-09-04 16:33:43', 1);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_player_other_group`
--

CREATE TABLE `tbl_player_other_group` (
  `player_other_groupid` bigint(20) NOT NULL,
  `playerid` bigint(20) NOT NULL,
  `sub_other_groupid` bigint(20) NOT NULL,
  `other_groupid` bigint(20) NOT NULL,
  `join_date` datetime NOT NULL,
  `end_date` datetime DEFAULT NULL,
  `createdate` datetime NOT NULL,
  `createuser` bigint(20) NOT NULL,
  `isactive` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `tbl_player_other_group`
--

INSERT INTO `tbl_player_other_group` (`player_other_groupid`, `playerid`, `sub_other_groupid`, `other_groupid`, `join_date`, `end_date`, `createdate`, `createuser`, `isactive`) VALUES
(1, 10, 1, 1, '2018-09-03 00:00:00', '2018-09-10 00:00:00', '2018-08-07 00:00:00', 1, 1),
(2, 11, 2, 1, '2018-09-03 00:00:00', '2018-10-31 00:00:00', '2018-08-07 00:00:00', 1, 1),
(3, 25, 1, 2, '0000-00-00 00:00:00', NULL, '2018-08-09 15:07:32', 1, 1),
(4, 32, 2, 1, '0000-00-00 00:00:00', NULL, '2018-08-11 14:03:21', 1, 1);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_setting`
--

CREATE TABLE `tbl_setting` (
  `SettingID` int(11) NOT NULL,
  `Name` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `Value` varchar(100) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `tbl_setting`
--

INSERT INTO `tbl_setting` (`SettingID`, `Name`, `Value`) VALUES
(1, 'Allow Login Failure Count', '5'),
(2, 'Password Validation', '8'),
(3, 'Admin Email', 'htethtetnay2@gmail.com'),
(4, 'SMTP', 'smtp.gmail.com'),
(5, 'Email', 'cardmanagementmm2018@gmail.com'),
(6, 'Email Password', 'cardmanagementmm2018!'),
(7, 'Server Port', '587'),
(8, 'Video Play Delay Time (Minute)', '10'),
(9, 'Company Name', 'SH'),
(10, 'Company Registeration No', '75358');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_sub_club`
--

CREATE TABLE `tbl_sub_club` (
  `sub_clubid` bigint(20) NOT NULL,
  `clubid` bigint(20) NOT NULL,
  `sub_clubname` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `create_date` datetime NOT NULL,
  `create_admin` bigint(20) NOT NULL,
  `isactive` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `tbl_sub_club`
--

INSERT INTO `tbl_sub_club` (`sub_clubid`, `clubid`, `sub_clubname`, `create_date`, `create_admin`, `isactive`) VALUES
(1, 1, 'AA', '2018-08-09 00:00:00', 1, 1),
(2, 1, 'BB', '2018-08-09 00:00:00', 1, 1),
(3, 2, 'u21', '2018-08-09 00:00:00', 1, 1),
(8, 8, 'YDNP1', '2018-08-14 10:07:35', 1, 1),
(9, 8, 'YDNP2', '2018-08-14 10:07:36', 1, 1),
(10, 9, 'YDNP1', '2018-08-14 10:12:28', 1, 1),
(11, 9, 'YDNP2', '2018-08-14 10:12:28', 1, 1),
(18, 12, 'UU', '2018-08-20 09:55:14', 1, 1),
(19, 11, 'U25', '2018-08-20 10:48:13', 1, 1),
(20, 11, 'U23', '2018-08-20 10:48:26', 1, 1),
(21, 12, 'ertyrtyyutyu', '2018-08-21 16:53:32', 1, 1),
(22, 13, 'ertyrtyyutyu', '2018-08-21 16:53:32', 1, 1),
(23, 14, 'ertyrtyyutyu', '2018-08-21 16:53:32', 1, 1),
(24, 15, 'ertyrtyyutyu', '2018-08-21 16:53:34', 1, 1),
(25, 16, 'ertyrtyyutyu', '2018-08-21 16:53:34', 1, 1),
(26, 17, 'ertyrtyyutyu', '2018-08-21 16:53:34', 1, 1),
(27, 20, 'e', '2018-08-21 16:53:37', 1, 1),
(28, 18, 'e', '2018-08-21 16:53:37', 1, 1),
(29, 19, 'e', '2018-08-21 16:53:37', 1, 1),
(30, 22, 'Senior', '2018-08-23 09:37:23', 1, 1),
(31, 22, 'Senior1', '2018-08-23 09:37:24', 1, 1),
(33, 23, 'MG1', '2018-09-05 14:04:27', 1, 1),
(34, 23, 'MG2', '2018-09-05 14:04:36', 1, 1),
(38, 24, 'SS1', '2018-09-05 15:02:34', 1, 1);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_sub_other_group`
--

CREATE TABLE `tbl_sub_other_group` (
  `sub_other_groupid` bigint(20) NOT NULL,
  `other_groupid` bigint(20) NOT NULL,
  `sub_other_groupname` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `create_date` datetime NOT NULL,
  `create_admin` bigint(20) NOT NULL,
  `isactive` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `tbl_sub_other_group`
--

INSERT INTO `tbl_sub_other_group` (`sub_other_groupid`, `other_groupid`, `sub_other_groupname`, `create_date`, `create_admin`, `isactive`) VALUES
(1, 1, 'AA', '2018-08-09 00:00:00', 1, 1),
(2, 1, 'BB', '2018-08-09 00:00:00', 1, 1),
(3, 2, 'u21', '2018-08-09 00:00:00', 1, 1),
(6, 7, 'Chin1', '2018-08-13 17:18:49', 1, 1),
(7, 7, 'Chin 2', '2018-08-13 17:18:57', 1, 1),
(8, 8, 'YDNP1', '2018-08-14 10:07:35', 1, 1),
(9, 8, 'YDNP2', '2018-08-14 10:07:36', 1, 1),
(10, 9, 'YDNP1', '2018-08-14 10:12:28', 1, 1),
(11, 9, 'YDNP2', '2018-08-14 10:12:28', 1, 1),
(16, 2, 'u22', '2018-08-14 15:43:23', 1, 1);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tbl_admin`
--
ALTER TABLE `tbl_admin`
  ADD PRIMARY KEY (`AdminID`);

--
-- Indexes for table `tbl_adminlevel`
--
ALTER TABLE `tbl_adminlevel`
  ADD PRIMARY KEY (`AdminLevelID`);

--
-- Indexes for table `tbl_adminmenu`
--
ALTER TABLE `tbl_adminmenu`
  ADD PRIMARY KEY (`AdminMenuID`);

--
-- Indexes for table `tbl_club`
--
ALTER TABLE `tbl_club`
  ADD PRIMARY KEY (`clubid`);

--
-- Indexes for table `tbl_club_attachment`
--
ALTER TABLE `tbl_club_attachment`
  ADD PRIMARY KEY (`attachid`);

--
-- Indexes for table `tbl_eventlog`
--
ALTER TABLE `tbl_eventlog`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `tbl_fingertemplatezk`
--
ALTER TABLE `tbl_fingertemplatezk`
  ADD PRIMARY KEY (`templateid`);

--
-- Indexes for table `tbl_general`
--
ALTER TABLE `tbl_general`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tbl_other_group`
--
ALTER TABLE `tbl_other_group`
  ADD PRIMARY KEY (`other_groupid`);

--
-- Indexes for table `tbl_player`
--
ALTER TABLE `tbl_player`
  ADD PRIMARY KEY (`playerid`);

--
-- Indexes for table `tbl_player_attachment`
--
ALTER TABLE `tbl_player_attachment`
  ADD PRIMARY KEY (`attachid`);

--
-- Indexes for table `tbl_player_category_history`
--
ALTER TABLE `tbl_player_category_history`
  ADD PRIMARY KEY (`historyid`);

--
-- Indexes for table `tbl_player_club`
--
ALTER TABLE `tbl_player_club`
  ADD PRIMARY KEY (`player_clubid`);

--
-- Indexes for table `tbl_player_club_attachment`
--
ALTER TABLE `tbl_player_club_attachment`
  ADD PRIMARY KEY (`attachid`);

--
-- Indexes for table `tbl_player_history`
--
ALTER TABLE `tbl_player_history`
  ADD PRIMARY KEY (`historyid`);

--
-- Indexes for table `tbl_player_other_group`
--
ALTER TABLE `tbl_player_other_group`
  ADD PRIMARY KEY (`player_other_groupid`);

--
-- Indexes for table `tbl_sub_club`
--
ALTER TABLE `tbl_sub_club`
  ADD PRIMARY KEY (`sub_clubid`);

--
-- Indexes for table `tbl_sub_other_group`
--
ALTER TABLE `tbl_sub_other_group`
  ADD PRIMARY KEY (`sub_other_groupid`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tbl_admin`
--
ALTER TABLE `tbl_admin`
  MODIFY `AdminID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT for table `tbl_adminlevel`
--
ALTER TABLE `tbl_adminlevel`
  MODIFY `AdminLevelID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `tbl_adminmenu`
--
ALTER TABLE `tbl_adminmenu`
  MODIFY `AdminMenuID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=78;
--
-- AUTO_INCREMENT for table `tbl_club`
--
ALTER TABLE `tbl_club`
  MODIFY `clubid` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;
--
-- AUTO_INCREMENT for table `tbl_club_attachment`
--
ALTER TABLE `tbl_club_attachment`
  MODIFY `attachid` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;
--
-- AUTO_INCREMENT for table `tbl_eventlog`
--
ALTER TABLE `tbl_eventlog`
  MODIFY `ID` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=574;
--
-- AUTO_INCREMENT for table `tbl_fingertemplatezk`
--
ALTER TABLE `tbl_fingertemplatezk`
  MODIFY `templateid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;
--
-- AUTO_INCREMENT for table `tbl_general`
--
ALTER TABLE `tbl_general`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;
--
-- AUTO_INCREMENT for table `tbl_other_group`
--
ALTER TABLE `tbl_other_group`
  MODIFY `other_groupid` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `tbl_player`
--
ALTER TABLE `tbl_player`
  MODIFY `playerid` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=51;
--
-- AUTO_INCREMENT for table `tbl_player_attachment`
--
ALTER TABLE `tbl_player_attachment`
  MODIFY `attachid` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=150;
--
-- AUTO_INCREMENT for table `tbl_player_category_history`
--
ALTER TABLE `tbl_player_category_history`
  MODIFY `historyid` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT for table `tbl_player_club`
--
ALTER TABLE `tbl_player_club`
  MODIFY `player_clubid` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;
--
-- AUTO_INCREMENT for table `tbl_player_club_attachment`
--
ALTER TABLE `tbl_player_club_attachment`
  MODIFY `attachid` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;
--
-- AUTO_INCREMENT for table `tbl_player_history`
--
ALTER TABLE `tbl_player_history`
  MODIFY `historyid` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;
--
-- AUTO_INCREMENT for table `tbl_player_other_group`
--
ALTER TABLE `tbl_player_other_group`
  MODIFY `player_other_groupid` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `tbl_sub_club`
--
ALTER TABLE `tbl_sub_club`
  MODIFY `sub_clubid` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=39;
--
-- AUTO_INCREMENT for table `tbl_sub_other_group`
--
ALTER TABLE `tbl_sub_other_group`
  MODIFY `sub_other_groupid` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
