﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using AutoDarkModeConfig;
using AutoDarkModeConfig.ComponentSettings;
using AutoDarkModeConfig.ComponentSettings.Base;

namespace AutoDarkModeConfig
{
    public class AdmConfig
    {
        public AdmConfig()
        {
            Location = new Location();
            Tunable = new Tunable();
            GPUMonitoring = new GPUMonitoring();
            Events = new Events();
            WindowsThemeMode = new WindowsThemeMode();

            //New Component Settings;
            AppsSwitch = new BaseSettingsEnabled<AppsSwitchSettings>();
            SystemSwitch = new BaseSettings<SystemSwitchSettings>();
            ColorFilterSwitch = new BaseSettings<object>();
            OfficeSwitch = new BaseSettings<OfficeSwitchSettings>();
            WallpaperSwitch = new BaseSettings<WallpaperSwitchSettings>();
        }
        public bool AutoThemeSwitchingEnabled { get; set; }
        public bool AutoUpdate { get; set; }
        public WindowsThemeMode WindowsThemeMode { get; set; }
        public BaseSettingsEnabled<AppsSwitchSettings> AppsSwitch { get; set; }
        public BaseSettings<SystemSwitchSettings> SystemSwitch { get; set; }
        public BaseSettings<object> ColorFilterSwitch { get; set; }
        public BaseSettings<OfficeSwitchSettings> OfficeSwitch { get; set; }
        public BaseSettings<WallpaperSwitchSettings> WallpaperSwitch { get; set; }
        public DateTime Sunrise { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 0, 0);
        public DateTime Sunset { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 19, 0, 0);
        public Location Location { get; set; }
        public Tunable Tunable { get; set; }
        public GPUMonitoring GPUMonitoring { get; set; }
        public Events Events { get; set; }
    }

    public class WindowsThemeMode
    {
        public bool Enabled { get; set; }
        public string DarkThemePath { get; set; }
        public string LightThemePath { get; set; }
    }

    public class Events
    {
        public bool DarkThemeOnBattery { get; set; }
        public bool SystemResumeTrigger { get; set; } = true;
    }

    public class Location
    {
        public TimeSpan PollingCooldownTimeSpan { get; set; } = TimeSpan.FromHours(24);
        public bool Enabled { get; set; }
        public bool UseGeolocatorService { get; set; } = true;
        public int SunsetOffsetMin { get; set; }
        public int SunriseOffsetMin { get; set; }
        public double CustomLat { get; set; }
        public double CustomLon { get; set; }
    }

    public class Tunable
    {
        private int batterySliderDefaultValue = 25;
        public int BatterySliderDefaultValue
        {
            get { return batterySliderDefaultValue; }
            set
            {
                if (value < 0)
                {
                    batterySliderDefaultValue = 0;
                }
                else if (value > 100)
                {
                    batterySliderDefaultValue = 100;
                }
                else
                {
                    batterySliderDefaultValue = value;
                }
            }
        }
        public bool DisableEnergySaverOnThemeSwitch { get; set; }
        public bool UseLogonTask { get; set; }
        public bool Debug { get; set; }
        public bool ShowTrayIcon { get; set; } = true;
    }

    public class GPUMonitoring
    {
        public bool Enabled { get; set; }
        public int Threshold { get; set; } = 30;
        private int monitorTimeSpanMin;
        public int MonitorTimeSpanMin
        {
            get { return monitorTimeSpanMin; }
            set
            {
                if (value <= 1)
                {
                    monitorTimeSpanMin = 1;
                }
                else
                {
                    monitorTimeSpanMin = value;
                }
            }
        }
        private int samples;
        public int Samples
        {
            get { return samples; }
            set
            {
                if (value < 1)
                {
                    samples = 1;
                }
                else
                {
                    samples = value;
                }
            }
        }
    }
}
