using WeatherMachine.Library.Garden.Extentions;
using Xunit;

namespace calibration.Day5
{
    public class FirstHalfGardenSpecification
    {
        [Fact]
        public void Any_source_numbers_that_arent_mapped_correspond_to_the_same_destination_number()
        {
            Garden.Map map = new Garden.Builder()
                .Build();

            map.From(1).Value.Should().Be(1);
        }

        [Fact]
        public void A_mapping_between_two_range_is_given_by_the_start_of_both_range_and_the_size_of_it()
        {
            Garden.Map map = new Garden.Builder()
                .RangeMap(50, 98, 2)
                .Build();

            map.From(98).Value.Should().Be(50);
            map.From(99).Value.Should().Be(51);
        }

        [Fact]
        public void Multiple_mapping_of_this_type_can_be_given()
        {
            Garden.Map map = new Garden.Builder()
                .RangeMap(50, 98, 2)
                .RangeMap(52, 50, 48)
                .Build();

            map.From(0).Value.Should().Be(0);
            map.From(1).Value.Should().Be(1);

            map.From(48).Value.Should().Be(48);
            map.From(49).Value.Should().Be(49);
            map.From(50).Value.Should().Be(52);
            map.From(51).Value.Should().Be(53);

            map.From(96).Value.Should().Be(98);
            map.From(97).Value.Should().Be(99);
            map.From(98).Value.Should().Be(50);
            map.From(99).Value.Should().Be(51);
        }

        [Fact]
        public void A_mapping_change_the_type_of_the_data_it_map()
        {
            Garden.Map map = new Garden.Builder("seed", "soil")
                .RangeMap(50, 98, 2)
                .RangeMap(52, 50, 48)
                .Build();

            map.From(0.Seed())
                .Should()
                .Be(0.Soil());
        }

        [Fact]
        public void we_can_conbine_multiple_mapper_together()
        {
            Garden.Map seedToSoil = new Garden.Builder("seed", "soil")
                .RangeMap(50, 98, 2)
                .RangeMap(52, 50, 48)
                .Build();

            Garden.Map soilToFertilizer = new Garden.Builder("soil", "fertilizer")
                .RangeMap(39, 0, 51)
                .Build();

            Garden.Map map = new Garden.ComposingBuilder("seed", "fertilizer")
                .Using(seedToSoil)
                .Using(soilToFertilizer)
                .Build();

            map.From(98.Seed())
                .Should()
                .Be(89.Fertilizer());
        }

        [Fact]
        public void map_can_be_configured_via_text()
        {
            Garden.Map map = new Garden.Builder()
                .FromText(@"seed-to-soil map:
50 98 2
52 50 48")
                .Build();

            map.From(0.Seed()).Value.Should().Be(0);
            map.From(1.Seed()).Value.Should().Be(1);
                     
            map.From(48.Seed()).Value.Should().Be(48);
            map.From(49.Seed()).Value.Should().Be(49);
            map.From(50.Seed()).Value.Should().Be(52);
            map.From(51.Seed()).Value.Should().Be(53);
                     
            map.From(96.Seed()).Value.Should().Be(98);
            map.From(97.Seed()).Value.Should().Be(99);
            map.From(98.Seed()).Value.Should().Be(50);
            map.From(99.Seed()).Value.Should().Be(51);
        }

        [Fact]
        public void composed_map_can_be_configured_via_text()
        {
            Garden.Map map = new Garden.ComposingBuilder("seed", "location")
                .FromText(@"seed-to-soil map:
50 98 2
52 50 48

soil-to-fertilizer map:
0 15 37
37 52 2
39 0 15

fertilizer-to-water map:
49 53 8
0 11 42
42 0 7
57 7 4

water-to-light map:
88 18 7
18 25 70

light-to-temperature map:
45 77 23
81 45 19
68 64 13

temperature-to-humidity map:
0 69 1
1 0 69

humidity-to-location map:
60 56 37
56 93 4")
                .Build();

            map.From(79.Seed())
                .Should()
                .Be(82.Location());
        }

        [Fact]
        public void The_almanach_is_the_combination_of_seeds_to_be_planted_and_a_map_of_need_for_those_seeds()
        {
            Garden.Almanach almanach = new Garden.AlmanachBuilder()
                .FromText(@"seeds: 79 14 55 13

seed-to-soil map:
50 98 2
52 50 48

soil-to-fertilizer map:
0 15 37
37 52 2
39 0 15

fertilizer-to-water map:
49 53 8
0 11 42
42 0 7
57 7 4

water-to-light map:
88 18 7
18 25 70

light-to-temperature map:
45 77 23
81 45 19
68 64 13

temperature-to-humidity map:
0 69 1
1 0 69

humidity-to-location map:
60 56 37
56 93 4")
                .Build();

            almanach.Seeds.Should().BeEquivalentTo(new[] { 79.Seed(), 14.Seed(), 55.Seed(), 13.Seed() });
        }
        [Fact]
        public void The_almanach_allows_the_user_to_find_the_location_with_the_smallest_id()
        {
            Garden.Almanach almanach = new Garden.AlmanachBuilder()
                .FromText(@"seeds: 79 14 55 13

seed-to-soil map:
50 98 2
52 50 48

soil-to-fertilizer map:
0 15 37
37 52 2
39 0 15

fertilizer-to-water map:
49 53 8
0 11 42
42 0 7
57 7 4

water-to-light map:
88 18 7
18 25 70

light-to-temperature map:
45 77 23
81 45 19
68 64 13

temperature-to-humidity map:
0 69 1
1 0 69

humidity-to-location map:
60 56 37
56 93 4")
                .Build();

            almanach.SmallestLocation().Should().Be(35.Location());
        }
    }
}
