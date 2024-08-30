using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ZserviceDesk.Models
{
    ////get_cpu_monitoring_by_serialnumber_sp
    ////get_disk_monitoring_by_serialnumber_sp
    ////get_memory_monitoring_by_serialnumber_sp
    ////get_network_monitoring_by_serialnumber_sp
    ////get_system_hardware_by_serialnumber_sp

    public class zdesk_m_switch_general_info_tbl
    {
        public Nullable<int> Id { get; set; }
        public Nullable<int> AssetCategory { get; set; }
        public string name { get; set; }
        public string run_time { get; set; }
        public string modelnumber { get; set; }
        public string serialnumber { get; set; }
        public string total_port { get; set; }
        public string ipaddress { get; set; }
        public string vendor { get; set; }
        public string lastupdate { get; set; }
        public string lastupdate_name { get; set; }
        public string AssetCategory_Name { get; set; }
        public string status { get; set; }
        public string AlertCount { get; set; }
        public string Description { get; set; }
    }

    public class zdesk_m_switch_memory_info_tbl
    {
        public Nullable<int> Id { get; set; }
        public string name { get; set; }
        public string serial_no { get; set; }
        public string memory_total { get; set; }
        public string memory_allocated { get; set; }
        public string memory_free { get; set; }
        public string memory_free_percent { get; set; }
        public string memory_uti_rising_threshold { get; set; }
        public string memory_uti_falling_threshold { get; set; }
        public string lastupdate { get; set; }
        public string lastupdate_name { get; set; }
    }

    public class zdesk_m_switch_cpu_utilization_tbl
    {
        public Nullable<int> Id { get; set; }
        public string name { get; set; }
        public string serial_no { get; set; }
        public string cpu_current_uti { get; set; }
        public string cpu_stat_max_uti { get; set; }
        public string cpu_stat_avg_uti { get; set; }
        public string cpu_peak_time { get; set; }
        public string cpu_peak_duration { get; set; }
        public string cpu_uti_rising_threshold { get; set; }
        public string cpu_uti_falling_threshold { get; set; }
        public string lastupdate { get; set; }
        public string lastupdate_name { get; set; }
    }

    public class zdesk_m_switch_interface_utilization_tbl
    {
        public Nullable<int> Id { get; set; }
        public string name { get; set; }
        public string serial_no { get; set; }
        public string input_octets_kbits_per_sec { get; set; }
        public string input_packtes_per_sec { get; set; }
        public string input_utilization { get; set; }
        public string output_octets_kbits_per_sec { get; set; }
        public string output_packtes_per_sec { get; set; }
        public string output_utilization { get; set; }
        public string port_no { get; set; }
        public string lastupdate { get; set; }
        public string lastupdate_name { get; set; }
    }

    public class zdesk_m_switch_interface_RMON_tbl
    {
        public Nullable<int> Id { get; set; }
        public string name { get; set; }
        public string serial_no { get; set; }
        public string drop_event { get; set; }
        public string jabbers { get; set; }
        public string fragments { get; set; }
        public string collisions { get; set; }
        public string recived_octest { get; set; }
        public string recived_packets { get; set; }
        public string broadcast_packets { get; set; }
        public string multicast_packets { get; set; }
        public string CRC_Align_Errors { get; set; }
        public string undersize_packets { get; set; }
        public string oversize_packets { get; set; }
        public string packets_64byte { get; set; }
        public string packets_65_127_byte { get; set; }
        public string packets_128_255_byte { get; set; }
        public string packets_256_511_byte { get; set; }
        public string packets_512_1023_byte { get; set; }
        public string packets_1024_1518_byte { get; set; }
        public string port_no { get; set; }
        public string lastupdate { get; set; }
        public string lastupdate_name { get; set; }
    }

    public class zdesk_m_switch_etherlike_record_tbl
    {
        public Nullable<int> Id { get; set; }
        public string name { get; set; }
        public string serial_no { get; set; }
        public string single_collision_frames { get; set; }
        public string multiple_collision_frames { get; set; }
        public string late_collisions { get; set; }
        public string excessive_collisions { get; set; }
        public string deferred_transmissions { get; set; }
        public string frames_too_long { get; set; }
        public string symbol_errors { get; set; }
        public string pause_frames_input { get; set; }
        public string pause_frames_output { get; set; }
        public string frc_errors { get; set; }
        public string mac_transmit_errors { get; set; }
        public string port_no { get; set; }
        public string lastupdate { get; set; }
        public string lastupdate_name { get; set; }
    }

    public class zdesk_m_switch_interface_port_record_tbl
    {
        public Nullable<int> Id { get; set; }
        public string name { get; set; }
        public string serial_no { get; set; }
        public string recived_octets { get; set; }
        public string recived_unicast_pkt { get; set; }
        public string recived_multicast_pkt { get; set; }
        public string recived_broadcast_pkt { get; set; }
        public string transmiited_octets { get; set; }
        public string transmitted_error { get; set; }
        public string transmitted_unicast_pkt { get; set; }
        public string transmitted_multicast_pkt { get; set; }
        public string transmitted_broadcast_pkt { get; set; }
        public string port_no { get; set; }
        public string lastupdate { get; set; }
        public string lastupdate_name { get; set; }
    }

    public class zdesk_m_switch_interface_port_tbl
    {
        public Nullable<int> Id { get; set; }
        public string name { get; set; }
        public string serial_no { get; set; }
        public string port_name { get; set; }
        public string recived_octets { get; set; }
        public string recived_unicast_pkt { get; set; }
        public string recived_multicast_pkt { get; set; }
        public string recived_broadcast_pkt { get; set; }
        public string transmiited_octets { get; set; }
        public string transmitted_error { get; set; }
        public string transmitted_unicast_pkt { get; set; }
        public string transmitted_multicast_pkt { get; set; }
        public string transmitted_broadcast_pkt { get; set; }
        public string ifindex { get; set; }
        public string macaddress { get; set; }
        public string switch_ip { get; set; }
        public string adminstatus { get; set; }
        public string port_no { get; set; }
        public string lastupdate { get; set; }
        public string lastupdate_name { get; set; }
    }
}

