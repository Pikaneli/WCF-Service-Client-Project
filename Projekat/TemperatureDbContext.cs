using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projekat
{
    public class TemperatureDbContext : DbContext
    {
        // 10 tabela u bazi sa istim tipovima podataka
        public DbSet<TemperatureReading> TemperatureReadings { get; set; }
        public DbSet<TemperatureReading2> TemperatureReadings2 { get; set; }
        public DbSet<TemperatureReading3> TemperatureReadings3 { get; set; }
        public DbSet<TemperatureReading4> TemperatureReadings4 { get; set; }
        public DbSet<TemperatureReading5> TemperatureReadings5 { get; set; }
        public DbSet<TemperatureReading6> TemperatureReadings6 { get; set; }
        public DbSet<TemperatureReading7> TemperatureReadings7 { get; set; }
        public DbSet<TemperatureReading8> TemperatureReadings8 { get; set; }
        public DbSet<TemperatureReading9> TemperatureReadings9 { get; set; }
        public DbSet<TemperatureReading10> TemperatureReadings10 { get; set; }

    }

    public class TemperatureReading
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
        public double Value { get; set; }

        public TemperatureReading() { }

        public TemperatureReading(int id, DateTime timestamp, double value)
        {
            Id = id;
            Timestamp = timestamp;
            Value = value;
        }
    }

    public class TemperatureReading2
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
        public double Value { get; set; }

        public TemperatureReading2() { }

        public TemperatureReading2(int id, DateTime timestamp, double value)
        {
            Id = id;
            Timestamp = timestamp;
            Value = value;
        }
    }

    public class TemperatureReading3
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
        public double Value { get; set; }

        public TemperatureReading3() { }

        public TemperatureReading3(int id, DateTime timestamp, double value)
        {
            Id = id;
            Timestamp = timestamp;
            Value = value;
        }
    }

    public class TemperatureReading4
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
        public double Value { get; set; }

        public TemperatureReading4() { }

        public TemperatureReading4(int id, DateTime timestamp, double value)
        {
            Id = id;
            Timestamp = timestamp;
            Value = value;
        }
    }

    public class TemperatureReading5
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
        public double Value { get; set; }

        public TemperatureReading5() { }

        public TemperatureReading5(int id, DateTime timestamp, double value)
        {
            Id = id;
            Timestamp = timestamp;
            Value = value;
        }
    }

    public class TemperatureReading6
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
        public double Value { get; set; }

        public TemperatureReading6() { }

        public TemperatureReading6(int id, DateTime timestamp, double value)
        {
            Id = id;
            Timestamp = timestamp;
            Value = value;
        }
    }

    public class TemperatureReading7
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
        public double Value { get; set; }

        public TemperatureReading7() { }

        public TemperatureReading7(int id, DateTime timestamp, double value)
        {
            Id = id;
            Timestamp = timestamp;
            Value = value;
        }
    }

    public class TemperatureReading8
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
        public double Value { get; set; }

        public TemperatureReading8() { }

        public TemperatureReading8(int id, DateTime timestamp, double value)
        {
            Id = id;
            Timestamp = timestamp;
            Value = value;
        }
    }

    public class TemperatureReading9
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
        public double Value { get; set; }

        public TemperatureReading9() { }

        public TemperatureReading9(int id, DateTime timestamp, double value)
        {
            Id = id;
            Timestamp = timestamp;
            Value = value;
        }
    }

    public class TemperatureReading10
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
        public double Value { get; set; }

        public TemperatureReading10() { }

        public TemperatureReading10(int id, DateTime timestamp, double value)
        {
            Id = id;
            Timestamp = timestamp;
            Value = value;
        }
    }
}