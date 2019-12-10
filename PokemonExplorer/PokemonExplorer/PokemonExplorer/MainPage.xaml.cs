using Newtonsoft.Json;
using PokemonExplorer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PokemonExplorer
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private HttpClient client = new HttpClient();
        public List<Pokemon> pokemonsValue = new List<Pokemon>();
        public List<Pokemon> pokemons
        {
            get => pokemonsValue;
            set
            {
                pokemonsValue = value;
                OnPropertyChanged(nameof(pokemons));
            }
        }
        public List<PokemonDetails> pokemonsDetailsValue = new List<PokemonDetails>();
        public List<PokemonDetails> pokemonsDetails
        {
            get => pokemonsDetailsValue;
            set
            {
                pokemonsDetailsValue = value;
                OnPropertyChanged(nameof(pokemonsDetails));
            }
        }
        public MainPage()
        {
            fetchPokemons();
            InitializeComponent();
            BindingContext = this;

        }
        public void fetchPokemons()
        {
            var response = client.GetAsync("https://pokeapi.co/api/v2/pokemon").Result;
            var result = JsonConvert.DeserializeObject<PokemonResponse>(response.Content.ReadAsStringAsync().Result);
            this.pokemons = result.Results.ToList();
            foreach(Pokemon p in this.pokemons)
            {
                response = client.GetAsync(p.Url).Result;
                var resultDetail = JsonConvert.DeserializeObject<PokemonDetails>(response.Content.ReadAsStringAsync().Result);

                this.pokemonsDetails.Add(resultDetail);


            }
        }
         async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
         {
            if (e.Item == null)
                return;


            var details = e.Item as PokemonDetails;
            await Navigation.PushModalAsync(new DetailPage(details.Name,details.Weight,details.Abilities.ToList(),details.Sprites.front_default,details.Sprites.back_default));

        }
    }
}
