audiomixer_sources = [
  'gstaudiomixer.c',
  'gstaudiomixerelement.c',
  'gstliveadder.c',
  'gstaudiointerleave.c',
  'gstaudiomixerplugin.c'
]

audiomixer_headers = [
  'gstaudiomixer.h',
  'gstaudiomixerelements.h',
  'gstaudiointerleave.h',
]

doc_sources = []
foreach s: audiomixer_sources + audiomixer_headers
  doc_sources += meson.current_source_dir() / s
endforeach

plugin_sources += {
  'audiomixer': pathsep.join(doc_sources)
}

if get_option('audiomixer').disabled()
  subdir_done()
endif

orcsrc = 'gstaudiomixerorc'
if have_orcc
  orc_h = custom_target(orcsrc + '.h',
    input : orcsrc + '.orc',
    output : orcsrc + '.h',
    command : orcc_args + ['--header', '-o', '@OUTPUT@', '@INPUT@'])
  orc_c = custom_target(orcsrc + '.c',
    input : orcsrc + '.orc',
    output : orcsrc + '.c',
    command : orcc_args + ['--implementation', '-o', '@OUTPUT@', '@INPUT@'])
  orc_targets += {'name': orcsrc, 'orc-source': files(orcsrc + '.orc'), 'header': orc_h, 'source': orc_c}
else
  orc_h = configure_file(input : orcsrc + '-dist.h',
    output : orcsrc + '.h',
    copy : true)
  orc_c = configure_file(input : orcsrc + '-dist.c',
    output : orcsrc + '.c',
    copy : true)
endif

gstaudiomixer = library('gstaudiomixer',
  audiomixer_sources + [orc_c, orc_h],
  c_args : gst_plugins_base_args,
  include_directories : [configinc],
  dependencies : [audio_dep, gst_base_dep, orc_dep],
  install : true,
  install_dir : plugins_install_dir,
)
plugins += [gstaudiomixer]
