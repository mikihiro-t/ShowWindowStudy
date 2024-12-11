using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;

namespace ShowWindowStudy.Sub;

public class SubViewModel
{
    public SubModel Model { get; set; }

    public SubViewModel(SubModel model)
    {
        Model = model;
    }
}