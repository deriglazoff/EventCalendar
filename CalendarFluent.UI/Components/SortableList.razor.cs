using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;
using static CalendarFluent.UI.Components.Pages.Home;

namespace CalendarFluent.UI.Components
{
	public partial class SortableList<T> where T : Item
	{

		[Parameter]
		public RenderFragment<T>? SortableItemTemplate { get; set; }

		[Parameter, AllowNull]
		public List<T> Items { get; set; }

		[Parameter]
		public EventCallback<(int oldIndex, int newIndex)> OnUpdate { get; set; }

		[Parameter]
		public EventCallback<(int oldIndex, int newIndex)> OnRemove { get; set; }

		[Parameter]
		public EventCallback<(int oldIndex, int newIndex, string from, string to)> OnAdd { get; set; }

		[Parameter]
		public string Id { get; set; } = Guid.NewGuid().ToString();

		[Parameter]
		public string Group { get; set; } = Guid.NewGuid().ToString();

		[Parameter]
		public string? Pull { get; set; }

		[Parameter]
		public bool Put { get; set; } = true;

		[Parameter]
		public bool Sort { get; set; } = true;

		[Parameter]
		public string Handle { get; set; } = string.Empty;

		[Parameter]
		public string? Filter { get; set; }

		[Parameter]
		public bool ForceFallback { get; set; } = true;

		private DotNetObjectReference<SortableList<T>>? _selfReference;

		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			if (firstRender)
			{
				_selfReference = DotNetObjectReference.Create(this);
				var module = await JS.InvokeAsync<IJSObjectReference>("import", "./Components/SortableList.razor.js");
				await module.InvokeAsync<string>("init", Id, Group, Pull, Put, Sort, Handle, Filter, _selfReference, ForceFallback);
			}
		}

		[JSInvokable]
		public void OnUpdateJS(int oldIndex, int newIndex)
		{
			OnUpdate.InvokeAsync((oldIndex, newIndex));
		}

		[JSInvokable]
		public void OnRemoveJS(int oldIndex, int newIndex)
		{
			OnRemove.InvokeAsync((oldIndex, newIndex));
		}
		[JSInvokable]
		public void OnAddJS(int oldIndex, int newIndex, string from, string to)
		{
			OnAdd.InvokeAsync((oldIndex, newIndex, from, to));
		}
		public void Dispose() => _selfReference?.Dispose();
	}
}